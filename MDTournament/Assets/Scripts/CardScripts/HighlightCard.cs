﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightCard : Card {

    int revenue;
    int damageBoost;

    public override void Initialize(CardAsset cardAsset) {
        base.Initialize(cardAsset);

        revenue = cardAsset.revenue;
        damageBoost = cardAsset.damageBoost;
    }

    public override void Play() { 

    }
}
