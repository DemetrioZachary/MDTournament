using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Fund, MeleeWeapon, RangedWeapon, Highlight, CrewMember, Ammo }

public class Card : MonoBehaviour {

    public CardType type;
    public string code;
    protected int cost;
    protected Sprite image;

    protected DeckController belongingDeck;

    //public virtual void Draw() { }
    public virtual void Play() { }
    public virtual void Discard() { }

    public virtual void InitializeCard(CardAsset cardAsset, DeckController belongingDeck) {
        this.belongingDeck = belongingDeck;
        code = cardAsset.code;
    }

    private void OnMouseUp() {
        Play();
        belongingDeck.Discard(this);
    }
}
