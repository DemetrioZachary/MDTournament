using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public const int DEFAULT_CARD_NUMBER = 5;
    public const int NUMBER_OF_PLAYERS = 3;

    private HandController[] players = new HandController[NUMBER_OF_PLAYERS];

    private int playerIndex = 0;
    private bool isFirstTurn = true;

    // -----------------------------------------------------
    private static GameManager s_Instance = null;

    public static GameManager instance {
        get {
            if (s_Instance == null) {
                Debug.LogError("Missing game manager");
            }
            return s_Instance;
        }
    }

    private void Awake() {
        s_Instance = FindObjectOfType<GameManager>();
    }
    // ----------------------------------------------------

    public void CreateControllers(CharacterAsset[] characterAssets) {
        if (characterAssets.Length != NUMBER_OF_PLAYERS) {
            Debug.LogError("Cannot create controllers: incoherent number of players");
            return;
        }

        for (int i = 0; i < NUMBER_OF_PLAYERS; i++) {
            players[i] = Instantiate(PrefabContainer.instance.handControllerPrefab);
            players[i].playerNumber = i;
            players[i].Initialize(characterAssets[i]);
        }

        // TEST
        DrawingPhase();
    }

    private void NextPlayer() {
        if (++playerIndex >= NUMBER_OF_PLAYERS) {
            playerIndex = 0;
        }

        // TEST
        DrawingPhase();
    }

    private void DrawingPhase() {
        int cardsToDraw = DEFAULT_CARD_NUMBER;
        if (isFirstTurn) {
            cardsToDraw -= NUMBER_OF_PLAYERS - playerIndex - 1;
            if (playerIndex + 1 == NUMBER_OF_PLAYERS)
                isFirstTurn = false;
        }

        for (int i = 0; i < cardsToDraw; i++) {
            players[playerIndex].DrawFromDeck(players[playerIndex].mainDeck);
        }

        // TEST
        print("Drawing" + playerIndex.ToString());
        playing = true;
    }

    // TEST
    bool playing = false;
    private void Update() {
        if (playing) {
            //print("Playing" + playerIndex.ToString());
            if (Input.GetKeyDown(KeyCode.Return)) {
                playing = false;
                DiscardPhase();
            }
        }
    }

    private void DiscardPhase() {
        players[playerIndex].DiscardAll();

        // TEST
        print("Discarding" + playerIndex.ToString());
        NextPlayer();
        
    }

    // Getters

    public HandController GetCurrentPlayer() {
        return players[playerIndex];
    }

    public HandController GetNextPlayer() {
        if (playerIndex + 1 >= NUMBER_OF_PLAYERS) {
            return players[0];
        }
        return players[playerIndex + 1];
    }

    public int GetCurrentPlayerIndex() {
        return playerIndex;
    }
}
