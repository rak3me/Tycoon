using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    CurrencyHandler currencyHandler;

    [Header("Level Info")]
    [SerializeField] private int level = 1;
    [SerializeField] private bool levelInProgress = false;
    [SerializeField] private float levelSecondsDuration = 120f;
    [SerializeField] private float levelSecondsElapsed = 0f;

    [Header("Debug Info")]
    [SerializeField] private bool debugMode = false;
    private GUIStyle debugUIStyle;


    // Use this for initialization
    private void Awake () {
        currencyHandler = FindObjectOfType<CurrencyHandler>();

        levelInProgress = false;
        levelSecondsElapsed = 0f;
    }

    // Update is called once per frame
    private void Update () {
        if (levelInProgress) {
            if (levelSecondsElapsed >= levelSecondsDuration) {
                EndDay();
            } else {
                levelSecondsElapsed += Time.deltaTime;
            }
        }
    }

    //For debugging purposes only. Any actual UI elements will be in the scene
    private void OnGUI () {
        if (!debugMode) return;

        if (GUI.Button(new Rect(0f, Screen.height - 50f, 100f, 50f), "New Game")) {
            NewGame();
        }

        if (GUI.Button(new Rect(120f, Screen.height - 50f, 100f, 50f), "Start Day")) {
            StartDay();
        }

        if (GUI.Button(new Rect(240f, Screen.height - 50f, 100f, 50f), "End Day")) {
            EndDay();
        }
    }

    //To be called when a new game is made
    //TODO: Look into making this a delegate, as there are NewGame functions in other scripts
    private void NewGame () {
        level = 1;
        levelInProgress = false;
    }

    //Next work day/level
    public void StartDay () {
        if (levelInProgress) {
            Debug.Log("Cannot Start a new day when one is already in progress!");
        } else {
            levelInProgress = true;
            levelSecondsDuration = 10f + (level - 1) * 1.2f;
            print("Level " + level);
        }
    }

    //Finish the level. To be called at a specified interval (ex. 8 hour work day)
    public void EndDay () {
        if (!levelInProgress) {
            Debug.Log("Cannot end a day when one hasn't started!");
        } else {
            level++;
            levelInProgress = false;
            levelSecondsElapsed = 0f;
        }
    }
}
