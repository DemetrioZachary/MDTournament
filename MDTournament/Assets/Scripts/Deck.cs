using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public DeckAsset asset = null;
    public Vector3 nextCardRelPos;

    protected Card nextCard = null;

    protected List<string> deck = new List<string>();

    protected Dictionary<string, CardAsset> cardAssetMap = new Dictionary<string, CardAsset>();
    protected Dictionary<string, int> quantityMap = new Dictionary<string, int>();

    private void Start() {
        if (asset)
            Initialize(asset);
    }

    public void Initialize(DeckAsset refAsset) {
        asset = refAsset;

        deck.Clear();

        for (int i = 0; i < refAsset.cardList.Count; i++) {
            string code = refAsset.cardList[i].code;
            if (!cardAssetMap.ContainsKey(code)) {
                cardAssetMap[code] = refAsset.cardList[i];
                quantityMap[code] = refAsset.quantityList[i];
                
                for (int j = 0; j < quantityMap[code]; j++) {
                    deck.Add(code);
                }
            }
        }
        Shuffle();

        Debug.Log("Cards total: " + (deck.Count).ToString());
    }

    protected void LoadNextCard() {
        if (nextCard) {
            Destroy(nextCard.gameObject);
            nextCard = null;
        }
        if (deck.Count > 0) {
            CardAsset nextCardAsset = cardAssetMap[deck[0]];
            nextCard = Instantiate(PrefabContainer.instance.GetCardPrefabByType(nextCardAsset.type), transform.parent);
            nextCard.transform.localPosition = nextCardRelPos;
            nextCard.Initialize(nextCardAsset);         
        }
    }

    public Card Draw() {
        Card drawCard = null;
        if (nextCard) {
            drawCard = nextCard;
            nextCard = null;
            deck.RemoveAt(0);
            LoadNextCard();
        }
        return drawCard;
    }

    public void Shuffle() {
        List<string> temp = new List<string>();
        while (deck.Count > 0) {
            int index = Random.Range(0, deck.Count);
            temp.Add(deck[index]);
            deck.RemoveAt(index);
        }
        deck = temp;
        LoadNextCard();
    }

    public int GetCardCount() {
        return deck.Count;
    }

    public int GetNextCardPrice() {
        if (nextCard)
            return nextCard.cost;
        return -1;
    }

    public void AddStash(List<string> stash) {
        foreach(string code in stash) {
            deck.Add(code);
        }
        Shuffle();
    }
}
