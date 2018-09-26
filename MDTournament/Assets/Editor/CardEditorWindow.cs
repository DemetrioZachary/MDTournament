using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CardEditorWindow : EditorWindow {

    // Data
    string code = "";
    CardType type = CardType.Fund;
    string cardName = "NewCardAsset";
    int cost = 0;
    Sprite image = null;
    string text = "";
    int revenue = 0;
    int damage = 0;
    int ammoCost = 0;
    int fireRate = 0;
    int damageBoost = 0;
    int memberArmor = 0;
    CrewMemberType memberType = CrewMemberType.Merc;


    [MenuItem("Window/Card Editor")]
    static void Init() {
        GetWindow<CardEditorWindow>("Card Editor");
    }

    Vector2 scrollPos;

    private void OnGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Card Editor", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Card")) {
            EditorUtility.FocusProjectWindow();
            CreateNewCard();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);


        // Start - CONTENT

        cardName = EditorGUILayout.TextField("Name", cardName);
        GUILayout.Space(5);
        code = EditorGUILayout.TextField("Code", code);
        GUILayout.Space(10);
        type = (CardType)EditorGUILayout.EnumPopup("Type", type);
        GUILayout.Space(10);
        cost = EditorGUILayout.IntField("Cost", cost);
        image = (Sprite)EditorGUILayout.ObjectField("Image", image, typeof(Sprite), false);

        GUILayout.Space(10);
        GUILayout.Label("Flavour Text");
        GUIStyle myAreaStyle = new GUIStyle(EditorStyles.textArea);
        myAreaStyle.wordWrap = true;
        text = EditorGUILayout.TextArea(text, myAreaStyle);
        GUILayout.Space(10);

        switch (type) {
            case CardType.Highlight:
            // Probably additional data about Melee/Ranged
            case CardType.Ammo:
                damageBoost = EditorGUILayout.IntField("Damage Boost", damageBoost);
                goto case CardType.Fund;
            case CardType.Fund:
                revenue = EditorGUILayout.IntField("Revenue", revenue);
                break;
            case CardType.RangedWeapon:
                ammoCost = EditorGUILayout.IntField("Ammo Cost", ammoCost);
                fireRate = EditorGUILayout.IntField("Fire Rate", fireRate);
                goto case CardType.MeleeWeapon;
            case CardType.MeleeWeapon:
                damage = EditorGUILayout.IntField("Damage", damage);
                break;
            case CardType.CrewMember:
                memberType = (CrewMemberType)EditorGUILayout.EnumPopup("Crew Member Type", memberType);
                memberArmor = EditorGUILayout.IntField("Crew Member Armor", memberArmor);
                damage = EditorGUILayout.IntField("Crew Member Damage", damage);
                // Probably additional data about Melee/Ranged
                break;
        }


        // End - CONTENT


        GUILayout.Space(10);

        EditorGUILayout.EndScrollView();
    }

    void CreateNewCard() {
        CardAsset cardAsset = CreateCardAssets.CreateSignleCard(type, cardName);
        Selection.activeObject = cardAsset;
        ApplyValues(cardAsset);
    }

    void ApplyValues(CardAsset cardAsset) {
        cardAsset.code = code;
        cardAsset.type = type;
        cardAsset.cardName = cardName;
        cardAsset.cost = cost;
        cardAsset.image = image;
        cardAsset.text = text;
        cardAsset.revenue = revenue;
        cardAsset.damage = damage;
        cardAsset.ammoCost = ammoCost;
        cardAsset.fireRate = fireRate;
        cardAsset.damageBoost = damageBoost;
        cardAsset.memberArmor = memberArmor;
        cardAsset.memberType = memberType;
    }
}
