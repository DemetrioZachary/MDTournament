using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Coords {
    public Transform characterTr;
    public Transform handTr;
    public Transform deckTr;
};

public class CoordsContainer : MonoBehaviour {

    public Coords[] coords;

    private static CoordsContainer s_Instance = null;

    public static CoordsContainer instance {
        get {
            if (s_Instance == null) {
                Debug.LogError("Missing coords container");
            }
            return s_Instance;
        }
    }

    private void Awake() {
        s_Instance = FindObjectOfType<CoordsContainer>();

        if (coords.Length != GameManager.NUMBER_OF_PLAYERS) {
            Debug.LogError("There aren't 3 coords setups for player cards");
        }
    }

    public Transform GetCharacterTransform(int playerIndex) {
        return coords[playerIndex].characterTr;
    }

    public Transform GetHandTransform(int playerIndex) {
        return coords[playerIndex].handTr;
    }

    public Transform GetDeckTransform(int playerIndex) {
        return coords[playerIndex].deckTr;
    }
}
