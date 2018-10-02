using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeaponCard : Card {

    int damage;
    int ammoCost;
    int fireRate;

    public override void Initialize(CardAsset cardAsset) {
        base.Initialize(cardAsset);

        damage = cardAsset.damage;
        ammoCost = cardAsset.ammoCost;
        fireRate = cardAsset.fireRate;
    }

    public override void Play() {

    }
}
