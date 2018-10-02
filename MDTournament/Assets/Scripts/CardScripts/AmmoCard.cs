using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCard : Card {

    int damageBoost;
    int sellValue;

    public override void Initialize(CardAsset cardAsset) {
        base.Initialize(cardAsset);

        damageBoost = cardAsset.damageBoost;
        sellValue = cardAsset.revenue;
    }

    public override void Play() {

    }
}
