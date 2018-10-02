using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableDeck : MonoBehaviour {

    public Deck deckComponent;
    public bool payCards = true;

    private void OnMouseUp() {
        // for 1 pc only
        GameManager.instance.GetCurrentPlayer().DrawFromDeck(deckComponent, payCards);
    }
}
