using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundCard : Card {

    int revenue;

    public override void Initialize(CardAsset cardAsset, DeckController belongingDeck) {
        base.Initialize(cardAsset, belongingDeck);

        revenue = cardAsset.revenue;
    }

    public override void Play() {

    }
}
