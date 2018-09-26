using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewCardAsset")]
public class CardAsset : ScriptableObject {

    public string code = "";

    public string cardName = "New Card Asset";
    public CardType type = CardType.Fund;

    public int cost = 0;
    public Sprite image = null;

    public string text = "";


    public int damage = 0;
    public int ammoCost = 0;
    public int fireRate = 0;
    public CrewMemberType memberType = CrewMemberType.Merc;
    public int memberArmor = 0;
    public int damageBoost = 0;
    public int revenue = 0;

}

[CustomEditor(typeof(CardAsset))]
public class CardAssetInspector : Editor {

    CardAsset asset;
    Vector2 scrollPos;

    private void OnEnable() {
        asset = (CardAsset)target;
    }

    public override void OnInspectorGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

        asset.cardName = EditorGUILayout.TextField("Name", asset.cardName);
        GUILayout.Space(5);
        asset.code = EditorGUILayout.TextField("Code", asset.code);
        GUILayout.Space(5);
        asset.type = (CardType)EditorGUILayout.EnumPopup("Type", asset.type);
        asset.cost = EditorGUILayout.IntField("Cost", asset.cost);
        asset.image = (Sprite)EditorGUILayout.ObjectField("Image", asset.image, typeof(Sprite), false);

        GUILayout.Space(10);
        GUILayout.Label("Flavour Text");
        GUIStyle myAreaStyle = new GUIStyle(EditorStyles.textArea);
        myAreaStyle.wordWrap = true;
        asset.text = EditorGUILayout.TextArea(asset.text, myAreaStyle);
        GUILayout.Space(20);

        switch (asset.type) {
            case CardType.Highlight:
            // Probably additional data about Melee/Ranged
            case CardType.Ammo:
                asset.damageBoost = EditorGUILayout.IntField("Damage Boost", asset.damageBoost);
                goto case CardType.Fund;
            case CardType.Fund:
                asset.revenue = EditorGUILayout.IntField("Revenue", asset.revenue);
                break;
            case CardType.RangedWeapon:
                asset.ammoCost = EditorGUILayout.IntField("Ammo Cost", asset.ammoCost);
                asset.fireRate = EditorGUILayout.IntField("Fire Rate", asset.fireRate);
                goto case CardType.MeleeWeapon;
            case CardType.MeleeWeapon:
                asset.damage = EditorGUILayout.IntField("Damage", asset.damage);
                break;
            case CardType.CrewMember:
                asset.memberType = (CrewMemberType)EditorGUILayout.EnumPopup("Crew Member Type", asset.memberType);
                asset.memberArmor = EditorGUILayout.IntField("Crew Member Armor", asset.memberArmor);
                asset.damage = EditorGUILayout.IntField("Crew Member Damage", asset.damage);
                // Probably additional data about Melee/Ranged
                break;
        }
        asset.name = asset.cardName;

        EditorGUILayout.EndScrollView();

        if (GUI.changed)
            EditorUtility.SetDirty(asset);
    }
}

