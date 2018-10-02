using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckAsset : ScriptableObject {

    public string deckName = "New Deck Asset";
    public List<CardAsset> cardList;
    public List<int> quantityList;
}
