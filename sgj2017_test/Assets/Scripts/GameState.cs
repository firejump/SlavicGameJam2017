﻿using System;
using System.Collections.Generic;

public class GameState {
    // 0 red 1 green 2 blue
    public int attackerColor = 0;
    public string getAttackerColorString() {
        return attackerColor == 0 ? ("red") : (attackerColor == 1 ? "green" : "blue");
    }
	public List<int> lastGameState=new List<int>();

    private GameState() {
        playerState = new PlayerState();
        setPlayerDefaults();
    }

    private void setPlayerDefaults()
    {
        playerState.setFeature("shape", "cube");
        playerState.setFeature("size", "l");
        playerState.setFeature("color", "blue");
        playerState.setFeature("character", "lazy");
        playerState.setFeature("lumination", "none");
    }


    public static GameState getInstance()
    {
        if (instance == null)
            instance = new GameState();
        return instance;
    }

    public PlayerState getPlayerState()
    {
        return playerState;
    }

    public void updatePlayerState(List<int> slots)
    {
		
        List<KeyValuePair<string, string>> featuresValues = PlayerState.getFeaturesAndValues();
        foreach (int slot in slots) {
            if (slot >= featuresValues.Count) {
                UnityEngine.Debug.Log("Slot above number of features!");
                continue;
            }
            KeyValuePair<string, string> featureValue = featuresValues[slot];
            getPlayerState().setFeature(featureValue.Key, featureValue.Value);
        }
		lastGameState = slots;
    }

    public void generateSlotsRules()
    {

    }

    public void startTowerDefense() {
        UnityEngine.Debug.Log("Start tower");
        UnityEngine.SceneManagement.SceneManager.LoadScene("bartekDevScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    private PlayerState playerState;
    private static GameState instance;
 

    public bool gameOver;
    public string bacteriaName;

    internal void restartGame() {
        ObstacleHandler.EXPLODED = false;
        gameOver = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("banditScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
