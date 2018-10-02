using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour {

    public CharacterAsset asset;
    private int armor = 0;

    public void Initialize(CharacterAsset asset) {
        this.asset = asset;
        armor = asset.armorPoints;
    }

    public void TakeDamage(int damage) {
        armor -= damage;
        if (armor < 0) {
            armor = -1;
            //Death
        }
    }
}
