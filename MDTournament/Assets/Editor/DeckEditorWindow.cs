using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DeckEditorWindow : EditorWindow {

    public List<DeckAsset> deckAssetList = new List<DeckAsset>();
    private int viewIndex = 1;

    [MenuItem("Window/Deck Editor")]
    static void Init() {
        GetWindow<DeckEditorWindow>("Deck Editor");
    }

    private void OnEnable() {
        deckAssetList.Clear();
        foreach(DeckAsset da in Resources.LoadAll<DeckAsset>("Decks")) {
            deckAssetList.Add(da);
        }
    }

    Vector2 scrollPos;
    
    private void OnGUI() {

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

        GUILayout.Label("Deck Editor", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("New Deck")) {
            EditorUtility.FocusProjectWindow();
            CreateNewDeck();
        }
        if (GUILayout.Button("Open Deck")) {
            OpenDeck();
        }
        if (deckAssetList.Count > 0) {
            if (deckAssetList != null) {
                if (GUILayout.Button("Show Deck")) {
                    EditorUtility.FocusProjectWindow();
                    Selection.activeObject = deckAssetList[viewIndex - 1];
                }
            }
            if (GUILayout.Button("Delete Deck")) {
                DeleteDeck(viewIndex - 1);
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        if (deckAssetList.Count > 0) {

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            GUILayout.Label(deckAssetList[viewIndex - 1].deckName, EditorStyles.boldLabel);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            viewIndex = Mathf.Clamp(EditorGUILayout.IntField(viewIndex, GUILayout.ExpandWidth(false)), 1, deckAssetList.Count);
            EditorGUILayout.LabelField("of   " + deckAssetList.Count.ToString() + "  decks", "", GUILayout.ExpandWidth(false));
            GUILayout.Space(10);
            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false))) {
                if (viewIndex > 1)
                    viewIndex--;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false))) {
                if (viewIndex < deckAssetList.Count)
                    viewIndex++;
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            // DATA

            deckAssetList[viewIndex - 1].deckName = EditorGUILayout.TextField("Deck Name", deckAssetList[viewIndex - 1].deckName as string);

            GUILayout.Space(10);
            for(int i=0; i< deckAssetList[viewIndex - 1].cardList.Count; i++) {
                GUILayout.BeginHorizontal();
                deckAssetList[viewIndex - 1].cardList[i] = EditorGUILayout.ObjectField(deckAssetList[viewIndex - 1].cardList[i], typeof(CardAsset), false) as CardAsset;
                deckAssetList[viewIndex - 1].quantityList[i] = EditorGUILayout.IntField(deckAssetList[viewIndex - 1].quantityList[i]);
                if (GUILayout.Button("X")) { RemoveCard(i); }
                GUILayout.EndHorizontal();
            }

            //...

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            if (GUILayout.Button("Add Card", GUILayout.ExpandWidth(false))) {
                AddCard();
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            EditorGUILayout.EndScrollView();
        }
        else {
            GUILayout.Label("No Deck Found");
        }
        if (GUI.changed) {
            if (deckAssetList.Count > 0) {
                EditorUtility.SetDirty(deckAssetList[viewIndex - 1]);
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(deckAssetList[viewIndex - 1]), deckAssetList[viewIndex - 1].deckName);
            }
        }
    }

    void CreateNewDeck() {
        viewIndex = 1;
        DeckAsset newDeckAsset = CreateCardAssets.CreateDeck("NewDeck");
        if (newDeckAsset) {
            newDeckAsset.cardList = new List<CardAsset>();
            newDeckAsset.quantityList = new List<int>();
            deckAssetList.Add(newDeckAsset);
            viewIndex = deckAssetList.Count;
        }
    }

    void OpenDeck() {
        string absPath = EditorUtility.OpenFilePanel("Select Deck Asset", "", "");
        if (absPath.StartsWith(Application.dataPath)) {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            DeckAsset deckAsset = AssetDatabase.LoadAssetAtPath(relPath, typeof(DeckAsset)) as DeckAsset;

            viewIndex = deckAssetList.IndexOf(deckAsset) + 1;
        }
    }

    void DeleteDeck(int index) {
        if (deckAssetList.Count > 0)
            AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(deckAssetList[index]));
        deckAssetList.RemoveAt(index);
    }

    void AddCard() {
        deckAssetList[viewIndex - 1].cardList.Add(new CardAsset());
        deckAssetList[viewIndex - 1].quantityList.Add(0);
    }

    void RemoveCard(int index) {
        deckAssetList[viewIndex - 1].cardList.RemoveAt(index);
        deckAssetList[viewIndex - 1].quantityList.RemoveAt(index);
    }
}
