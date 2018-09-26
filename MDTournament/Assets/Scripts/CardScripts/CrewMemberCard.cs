using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrewMemberType { Merc, Fan, Pro, Auto }

public class CrewMemberCard : Card {

    CrewMemberType memberType;
    int memberArmor;
    int memberDamage;

    public override void Initialize(CardAsset cardAsset, DeckController belongingDeck) {
        base.Initialize(cardAsset, belongingDeck);

        memberType = cardAsset.memberType;
        memberArmor = cardAsset.memberArmor;
        memberDamage = cardAsset.damage;
    }

    public override void Play() {

    }
}
