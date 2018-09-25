using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class CardEditorWindow : EditorWindow {

    // Data
    CardType type = CardType.Fund;
    string cardName="NewCardAsset";
    int cost = 0;
    Sprite image;


    [MenuItem("Window/Card Editor")]
    static void Init() {
        GetWindow<CardEditorWindow>("Card Editor");
    }

    private void OnGUI() {

        GUILayout.BeginHorizontal();
        GUILayout.Label("Card Editor", EditorStyles.boldLabel);
        if (GUILayout.Button("Create Card")) {
            EditorUtility.FocusProjectWindow();
            CreateNewCard();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);


        // Start - CONTENT

        cardName = EditorGUILayout.TextField("Name", cardName);
        type = (CardType)EditorGUILayout.EnumPopup("Type", type);
        cost = EditorGUILayout.IntField("Cost", cost);
        image = (Sprite)EditorGUILayout.ObjectField("Image", image, typeof(Sprite), false);

        // End - CONTENT


        GUILayout.Space(10);
    }

    void CreateNewCard() {
        CardAsset cardAsset = CreateCardAssets.CreateSignleCard(type, cardName);
        Selection.activeObject = cardAsset;
        ApplyValues();
    }

    void ApplyValues() {

    }
}
