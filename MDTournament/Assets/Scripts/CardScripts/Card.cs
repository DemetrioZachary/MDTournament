using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType { Fund, MeleeWeapon, RangedWeapon, Highlight, CrewMember, Ammo }

public abstract class Card : MonoBehaviour {

    public CardType type;
    public string code;
    public int cost;
    protected Sprite image;
    protected string text;

    //public virtual void Draw() { }
    public virtual void Play() { }
    //public virtual void Discard() { }

    public virtual void Initialize(CardAsset cardAsset) {
        code = cardAsset.code;
        type = cardAsset.type;
        cost = cardAsset.cost;
        image = cardAsset.image;
        text = cardAsset.text;
        name = cardAsset.name;
    }

    private void OnMouseUp() {
        Play();
        GameManager.instance.GetCurrentPlayer().Discard(this);
    }
}
