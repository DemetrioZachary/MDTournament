﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour {


    public Deck mainDeck;
    public Stash stash;
    public Character character;
    public int playerIndex;

    public int funds = 0;

    public Text fundText;

    private List<Card> handCards = new List<Card>();
    private Transform cardsMiddle;

    public void Initialize(int playerIndex, CharacterAsset characterAsset) {
        this.playerIndex = playerIndex;

        mainDeck = Instantiate(PrefabContainer.instance.deckPrefab, CoordsContainer.instance.GetDeckTransform(playerIndex)) as Deck;
        mainDeck.Initialize(characterAsset.starterGears);

        stash = Instantiate(PrefabContainer.instance.stashPrefab, transform) as Stash;
        stash.Initialize();

        character = Instantiate(PrefabContainer.instance.characterPrefab, CoordsContainer.instance.GetCharacterTransform(playerIndex)) as Character;
        character.Initialize(characterAsset);

        cardsMiddle = CoordsContainer.instance.GetHandTransform(playerIndex);
    }

    public int GetHandCardsCount() {
        return handCards.Count;
    }

    public void Discard(Card card) {
        stash.AddToStash(card.code);
        handCards.Remove(card);
        Destroy(card.gameObject);
        ReorganizeCards();
    }

    public void DiscardAll() {
        while (handCards.Count > 0) {
            Discard(handCards[0]);
        }
    }

    public void DrawFromDeck(Deck deck, bool pay = false) {
        Card newCard = null;

        if (pay) {
            int price = deck.GetNextCardPrice();
            if (price <= funds) {
                newCard = deck.Draw();
                funds -= price;
            }
        }
        else {
            newCard = deck.Draw();
        }

        if (newCard) {
            handCards.Add(newCard);
            newCard.transform.parent = cardsMiddle;
            ReorganizeCards();
        }

        if (mainDeck.GetCardCount() == 0) {
            mainDeck.AddStash(stash.GetStashList());
            stash.ClearStash();
        }
    }

    private void ReorganizeCards() {

        float DIST = 0.4f;

        for (int i = 0; i < handCards.Count; i++) {
            handCards[i].transform.localPosition = new Vector3(DIST * (2f * i - handCards.Count + 1f), 0, 0);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            //Debug.Log("Deck: " + mainDeck.GetCardCount().ToString() + "; Hand: " + handCards.Count + "; Trash: " + stash.GetStashList().Count);
        }
        //fundText.text = funds.ToString();
    }
}
