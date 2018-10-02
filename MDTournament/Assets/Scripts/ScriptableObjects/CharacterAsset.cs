using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "NewCharacterAsset")]
public class CharacterAsset : ScriptableObject {

    public string characterName = "";
    public int armorPoints = 0;
    public DeckAsset starterGears;

    public Sprite image;
    public string text;

    // character abilities
}


[CustomEditor(typeof(CharacterAsset))]
public class CharacterAssetInspector : Editor {

    private CharacterAsset asset;
    private Vector2 scrollPos;

    private void OnEnable() {
        asset = (CharacterAsset)target;
    }

    public override void OnInspectorGUI() {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, false);

        asset.characterName = EditorGUILayout.TextField("Name", asset.characterName);

        GUILayout.Space(5);
        asset.armorPoints = EditorGUILayout.IntField("Armor Points", asset.armorPoints);
        asset.image = (Sprite)EditorGUILayout.ObjectField("Image", asset.image, typeof(Sprite), false);

        GUILayout.Space(10);
        GUILayout.Label("Flavour Text");
        GUIStyle myAreaStyle = new GUIStyle(EditorStyles.textArea);
        myAreaStyle.wordWrap = true;
        asset.text = EditorGUILayout.TextArea(asset.text, myAreaStyle);

        asset.name = asset.characterName;

        EditorGUILayout.EndScrollView();

        if (GUI.changed)
            EditorUtility.SetDirty(asset);
    }
}
