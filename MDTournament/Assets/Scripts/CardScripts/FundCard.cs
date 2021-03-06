﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundCard : Card {

    int revenue;

    public override void Initialize(CardAsset cardAsset) {
        base.Initialize(cardAsset);

        revenue = cardAsset.revenue;
    }

    public override void Play() {
        GameManager.instance.GetCurrentPlayer().funds += revenue;
    }
}
