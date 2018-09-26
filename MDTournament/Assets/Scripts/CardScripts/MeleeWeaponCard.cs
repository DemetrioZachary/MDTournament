using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponCard : Card {

    public int damage;

    public override void Initialize(CardAsset cardAsset, DeckController belongingDeck) {
        base.Initialize(cardAsset, belongingDeck);

        damage = cardAsset.damage;
    }

    public override void Play() {
        
    }
}
