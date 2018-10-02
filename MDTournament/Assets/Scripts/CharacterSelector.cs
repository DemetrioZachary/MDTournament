using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

    const string CHARACTERS_PATH = "Characters";

    public Dropdown[] dropDowns;

    private CharacterAsset[] characterAssets;

    private void Start() {

        characterAssets = Resources.LoadAll<CharacterAsset>(CHARACTERS_PATH);

        foreach (Dropdown dropDown in dropDowns) {
            dropDown.ClearOptions();
            List<string> names = new List<string>();
            foreach (CharacterAsset c in characterAssets) {
                names.Add(c.name);
            }
            dropDown.AddOptions(names);
        }
    }

    public void StartGame() {
        CharacterAsset[] selected = new CharacterAsset[dropDowns.Length];
        for (int i = 0; i < dropDowns.Length; i++) {
            selected[i] = characterAssets[dropDowns[i].value];
        }

        //Debug.Log("1: " + selected[0].name + "  / 2: " + selected[1].name + "  / 3: " + selected[2].name);

        GameManager.instance.CreateControllers(selected);
        gameObject.SetActive(false);
    }
}
