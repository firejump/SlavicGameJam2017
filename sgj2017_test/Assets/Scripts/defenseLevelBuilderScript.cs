using System;
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

    private string heightMap = "dUu    ";

    private string[,] map = {
        { " ", " ", " ", " ", " " , " ", " "},
        { " ", "7", "-", "-", "-" , "9", " "},
        { " ", "|", " ", " ", " " , "|", " "},
        { " ", "|", " ", " ", " " , "1", "-"},
        { " ", "1", "-", "9", " ", " ", " "},
        { " ", " ", " ",  "|", " " , " ", " "},
        { " ", " ", " ",  "|", " " , " ", " "}, 
       };
    // Use this for initialization
    void Start () {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            float y = 0;

            char height = heightMap[x];
            if (height == 'U')
            {
                y = 0.5f;
            }
            for (int z = 0; z < map.GetLength(1); z++)
            {
                string s = map[x, z];
                bool hasLight = s[0] != ' ';
                if (hasLight)
                {
                    Instantiate(tileLight, new Vector3(x, y, z), Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == ' ')
                {
                    InstantiatePochyly(height, grass, grassPochyly, new Vector3(x, y, z), Quaternion.Euler(0,0,0));
                }
                if (s[0] == '|')
                {
                    InstantiatePochyly(height, road, roadPochyly, new Vector3(x, y, z), Quaternion.Euler(0,90,0));
                }
                if (s[0] == '-')
                {
                    Instantiate(road, new Vector3(x, y, z), Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == '9')
                {
                    Instantiate(roadTurn, new Vector3(x, y, z), Quaternion.Euler(0, 180, 0));
                }
                if (s[0] == '3')
                {
                    Instantiate(roadTurn, new Vector3(x, y, z), Quaternion.Euler(0, 270, 0));
                }
                if (s[0] == '1')
                {
                    Instantiate(roadTurn, new Vector3(x, y, z), Quaternion.Euler(0, 0, 0));
                }
                if (s[0] == '7')
                {
                    Instantiate(roadTurn, new Vector3(x, y, z), Quaternion.Euler(0, 90, 0));
                }
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



    // Update is called once per frame
    void Update () {
		
	}
}
