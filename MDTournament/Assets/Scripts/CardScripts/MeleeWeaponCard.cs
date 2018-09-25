using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponCard : Card {

    public int damage;

    public override void InitializeCard(CardAsset cardAsset, DeckController belongingDeck) {
        base.InitializeCard(cardAsset, belongingDeck);

        damage = cardAsset.damage;
    }

    public override void Play() {
        
    }
}
