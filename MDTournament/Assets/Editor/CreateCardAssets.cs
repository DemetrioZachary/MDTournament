using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateCardAssets {

    static string[] typePath = { "Funds/", "MeleeWeapons/", "RangedWeapons", "Highligths/", "CrewMembers/", "Ammos/" };


    public static DeckAsset CreateDeck(string name) {
        DeckAsset asset = ScriptableObject.CreateInstance<DeckAsset>();

        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Decks/" + name + ".asset"));
        AssetDatabase.SaveAssets();
        return asset;
    }


    public static CardAsset CreateSignleCard(CardType type, string name) {
        CardAsset asset = ScriptableObject.CreateInstance<CardAsset>();

        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/Cards/" + typePath[(int)type] + name + ".asset"));
        AssetDatabase.SaveAssets();
        return asset;
    }
}
