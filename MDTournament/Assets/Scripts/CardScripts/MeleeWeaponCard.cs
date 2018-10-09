using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponCard : Card {

    public int damage;

    public override void Initialize(CardAsset cardAsset) {
        base.Initialize(cardAsset);

        damage = cardAsset.damage;
    }

    public override void Play() {
        // open target selection menu

        GameManager.instance.GetNextPlayer().character.TakeDamage(damage);
    }
    
}
