using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour {

    public DeckAsset deckAsset;
    public Transform handPosition;

    private Card nextCard = null;

    private Queue<string> deck = new Queue<string>();
    private List<Card> handCards = new List<Card>();
    private List<string> trash = new List<string>();

    private Dictionary<string, CardAsset> cardAssetMap = new Dictionary<string, CardAsset>();
    private Dictionary<string, int> quantityMap = new Dictionary<string, int>();

    private void Start() {
        InitializeDeck(deckAsset);
    }

    public void InitializeDeck(DeckAsset refAsset) {
        deck.Clear();
        trash.Clear();

        for (int i = 0; i < refAsset.cardList.Count; i++) {
            string code = refAsset.cardList[i].code;
            if (!cardAssetMap.ContainsKey(code)) {
                cardAssetMap[code] = refAsset.cardList[i];
                quantityMap[code] = refAsset.quantityList[i];
                
                for (int j = 0; j < quantityMap[code]; j++) {
                    trash.Add(code);
                }
            }
        }
        ShuffleTrash();
        LoadNextCard();

        Debug.Log("Cards total: " + (deck.Count + 1).ToString());
    }
    
    public void ShuffleTrash() {
        //Debug.Log("Shuffling");
        while (trash.Count > 0) {
            int index = Random.Range(0, trash.Count);
            deck.Enqueue(trash[index]);
            trash.RemoveAt(index);
        }
    }

    public void Discard(Card card) {
        trash.Add(card.code);
        handCards.Remove(card);
        Destroy(card.gameObject);
    }

    private void LoadNextCard() {
        //Debug.Log("Loading next card");
        if (deck.Count == 0) {
            ShuffleTrash();
        }
        if (deck.Count > 0) {
            CardAsset nextCardAsset = cardAssetMap[deck.Dequeue()];
            nextCard = Instantiate(PrefabContainer.instance.GetCardPrefabByType(nextCardAsset.type), Vector3.zero, Quaternion.Euler(90, 0, 0), transform.parent);
            nextCard.InitializeCard(nextCardAsset, this);         
        }
    }

    private void OnMouseUp() {
        if (nextCard) {
            handCards.Add(nextCard);
            nextCard.transform.position = handPosition.position + new Vector3(0, 0, -handCards.IndexOf(nextCard) * 1.01f);
            nextCard = null;
            LoadNextCard();
        }
    }


    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("Deck: " + (deck.Count + (nextCard == null ? 0 : 1)).ToString() + "; Hand: " + handCards.Count + "; Trash: " + trash.Count);
        }
    }
}
