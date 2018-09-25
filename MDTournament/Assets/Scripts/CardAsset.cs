using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewCardAsset")]
public class CardAsset : ScriptableObject {

    public string code = "";

    public string cardName = "New Card Asset";
    public CardType type = CardType.Fund;

    public int cost = 0;
    public Sprite image;
    public string text;
    public int damage;
    public int ammoCost;
    public int fireRate;
    public int memberArmor;
    public int damageBoost;
    public int revenue;

    // ...
}

