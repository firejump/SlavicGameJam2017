﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defenseLevelBuilderScript : MonoBehaviour {
    public GameObject road;
    public GameObject roadTurn;

    public GameObject roadPochyly;
    public GameObject grass;
    public GameObject grassPochyly;
    public GameObject tileLight;
    public GameObject attackerRed;
    public GameObject attackerGreen;
    public GameObject attackerBlue;
    public GameObject ravine;
    public GameObject rock;
    public GameObject darkness;

    public GameObject bacteriaNameText;


    private GameObject getAttacker() {
        if (GameState.getInstance().attackerColor == 0) return attackerRed;
        if (GameState.getInstance().attackerColor == 1) return attackerGreen;
        return attackerBlue;
    }

    public GameObject player; // this is actually player and camera

    private int mapBorderWidth = 10;

    private string heightMap = "  dUu         ";

    // WARNING: map can't have roads on the map edge! (waypoints algo will break)
    // WARNING: start & endpoint can only have one road neighbour
    // WARNING: roads can't touch each other on edges (corners are OK)
    // 1,7,9,3: rotated road (like on numpad)
    // 8 6 2 4 - rotated attacker flower
    // " " == grass
    // s == start point
    // r = ravine (wąwóz)
    // R = rock
    // l = no light
    // L = no light event trigger
    private string[,] map = {
        { " ", " ", " ", " ", " " , " ", " ", " "},
        { " ", "7", "-l", "-lL", "-l" , "9", " ", " "},
        { " ", "|", " ", " ", " " , "|", " ", " "},
        { " ", "|", " ", " R", " " , "|", " ", " "},
        { " ", "|", " ", " ", " " , "|", " ", " "},
        { " 6", "|", " ", " ", " " , "|", " ", " "},
        { " ", "|", " 4", " ", " " , "1", "-", " "},
        { " ", "1", "-", "9", " ", " ", " ", " "},
        { " ", " ", " ",  "|", " " , " ", " ", " "},
        { " ", " ", " ",  "|r", " " , " ", " ", " "},
        { " ", " ", " ",  "|", " " , " ", " ", " "},
        { " ", " ", " ",  "|", " " , " ", " ", " "},
        { " ", " ", " ",  "|s", " " , " ", " ", " "},
        { " ", " ", " ", " ", " " , " ", " ", " "},
       };

    private List<char> roadTiles = new List<char> { '|', '-', '7', '9', '3', '1' };
    private bool isRoad(int x, int z) {
        return roadTiles.Contains(map[x, z][0]);
    }

    void Start () {
        GenerateWaypoints();
        player.GetComponent<Transform>().position = waypoints[0];
        instantiateMapTiles();
        instantiateBorders();
        GameState.getInstance().bacteriaName = BacteriaNamesScript.getNewName();
        bacteriaNameText.GetComponent<UnityEngine.UI.Text>().text = GameState.getInstance().bacteriaName;

    }


    private void instantiateMapTiles() {
        for (int x = 0; x < map.GetLength(0); x++) {
            float y = 0;

            char height = heightMap[x];
            if (height == 'U') {
                y = 0.5f;
            }
            for (int z = 0; z < map.GetLength(1); z++) {
                string s = map[x, z];
                bool hasLight = s[0] != ' ' && !s.Contains("l") ;
                Vector3 position = new Vector3(x, y, z);
                if (hasLight) {
                    Instantiate(tileLight, position, Quaternion.Euler(0, 0, 0));
                }
                // road, grass
                if (s[0] == ' ') {
                    InstantiatePochyly(height, grass, grassPochyly, position, Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == '|') {
                    InstantiatePochyly(height, road, roadPochyly, position, Quaternion.Euler(0, 90, 0));
                }
                if (s[0] == '-') {
                    Instantiate(road, position, Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == '9') {
                    Instantiate(roadTurn, position, Quaternion.Euler(0, 180, 0));
                }
                if (s[0] == '3') {
                    Instantiate(roadTurn, position, Quaternion.Euler(0, 270, 0));
                }
                if (s[0] == '1') {
                    Instantiate(roadTurn, position, Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == '7') {
                    Instantiate(roadTurn, position, Quaternion.Euler(0, 90, 0));
                }

                // flower

                if (s.Contains("6")) Instantiate(getAttacker(), position, Quaternion.Euler(0, 0, 0));
                if (s.Contains("2")) Instantiate(getAttacker(), position, Quaternion.Euler(0, 90, 0));
                if (s.Contains("4")) Instantiate(getAttacker(), position, Quaternion.Euler(0, 180, 0));
                if (s.Contains("8")) Instantiate(getAttacker(), position, Quaternion.Euler(0, 270, 0));

                if (s.Contains("r")) Instantiate(ravine, position, Quaternion.Euler(0, 90, 0));
                if (s.Contains("R")) Instantiate(rock, position, Quaternion.Euler(0, 0, 0));
                if (s.Contains("L")) Instantiate(darkness, position, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    private void instantiateBorders() {
        for (int x = -mapBorderWidth; x < map.GetLength(0) + mapBorderWidth; x++) {
            float y = 0;
            char height;
            if (x >= 0 && x < map.GetLength(0)) {
                height = heightMap[x];
            }
            else {
                height = ' ';
            }
            if (height == 'U') {
                y = 0.5f;
            }
            for (int z = -mapBorderWidth; z < map.GetLength(1) + mapBorderWidth; z++) {
                if (x >=0 && x < map.GetLength(0) && z >=0 && z < map.GetLength(1)) {
                    //in map, skip
                    continue;
                }
                Vector3 position = new Vector3(x, y, z);
                InstantiatePochyly(height, grass, grassPochyly, position, Quaternion.Euler(0, 0, 0));
            }
        }
    }

    private void InstantiatePochyly(char height, GameObject terrain, GameObject terrainPochyly, Vector3 position, Quaternion baseRotation)
    {
        if (height == ' ' || height == 'U')
        {
            Instantiate(terrain, position, baseRotation);
        }
        if (height == 'u')
        {
            Instantiate(terrainPochyly, position, baseRotation);
        }
        if (height == 'd')
        {
            Instantiate(terrainPochyly, position, baseRotation * Quaternion.Euler(0,180,0));
        }
    }

    private void GenerateWaypoints()
    {
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int z = 0; z < map.GetLength(1); z++) {
                if (map[x, z].Contains("s")) {
                    FindWaypointsDFS(x, z, 0, 0);
                    return;
                }
            }
        }

        
    }

    private int[,] possibleMoves = new int[4,2] { { 1, 0 }, { -1, 0 }, { 0, -1 }, { 0, 1 } };

    private void FindWaypointsDFS(int x, int z, int prevX, int prevZ) {
        AddWaypoint(x, z);
        for (int move = 0; move < possibleMoves.GetLength(0); move++) {
            int newx = x + possibleMoves[move,0];
            int newz = z + possibleMoves[move,1];
            if (!(newx == prevX && newz == prevZ) && isRoad(newx, newz)) {
                FindWaypointsDFS(newx, newz, x, z);
            }
        }

    }

    private List<Vector3> waypoints = new List<Vector3>();
    private void AddWaypoint(int x, int z) {
        float y = 1;
        char height = heightMap[x];
        if (height == 'U') y = 1.5f;
        if(height == 'u' || height == 'd') y = 1.25f;
        waypoints.Add(new Vector3(x, y, z));
    }
    private int timeStepsElapsed = 0;
    private int timeStepsPerWaypoint = 30;
    private int delayStartSteps = 120;
    private int delayGameOver = 200;
    private int gameOverTime = 0;

    void FixedUpdate () {
        if (GameState.getInstance().gameOver) {
            if (gameOverTime == 0) gameOverTime = timeStepsElapsed;
            timeStepsElapsed++;
            if (timeStepsElapsed > gameOverTime + delayGameOver) {
                GameState.getInstance().restartGame();
            }
            return;
        }
        /*
            // EXPLODING
            // player contains camera and player, we need to grab player prefab only.
            GameObject actualPlayer = GameObject.FindGameObjectsWithTag("Player")[0];
            ParticleExploderScript.Explode(actualPlayer, player.GetComponent<Transform>().position);
            Destroy(actualPlayer);
            timeStepsElapsed++;
            return;
        */

        if (timeStepsElapsed >= delayStartSteps) {
            int timeStepsSinceMovingStarts = timeStepsElapsed - delayStartSteps;
            int prevWaypointId = timeStepsSinceMovingStarts / timeStepsPerWaypoint;
            if (prevWaypointId + 1 >= waypoints.Count) {
                return;
            }
            int frameId = timeStepsSinceMovingStarts % timeStepsPerWaypoint;
            Vector3 newPos = waypoints[prevWaypointId + 1] * ((float)frameId / timeStepsPerWaypoint) + waypoints[prevWaypointId] * (1 - (float)frameId / timeStepsPerWaypoint);

            player.GetComponent<Transform>().position = newPos;
        }
        timeStepsElapsed++;
	}
}
