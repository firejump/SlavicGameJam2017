﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public static string[] FEATURE_SEQUENCE = { "shape", "size", "color", "character", "lumination" };

    private static Dictionary<string, PlayerComposer> PLAYER_COMPOSERS = new Dictionary<string, PlayerComposer>()
    {
        { "shape:cube", new CubeComposer() },
        { "shape:ball", new BallComposer() },
        { "size:s", new SizeComposer(0.67f) },
        { "size:m", new SizeComposer(1.00f) },
        { "size:l", new SizeComposer(1.50f) },
        { "color:yellow", new ColorComposer(Resources.Load<Material>("ColorMaterials/Yellow")) },
        { "color:red", new ColorComposer(Resources.Load<Material>("ColorMaterials/Red")) },
        { "color:green", new ColorComposer(Resources.Load<Material>("ColorMaterials/Green")) },
        { "color:blue", new ColorComposer(Resources.Load<Material>("ColorMaterials/Blue")) },
        { "character:lazy", new EmptyComposer() },
        { "character:energetic", new JumpComposer() },
        { "lumination:none", new EmptyComposer() },
        { "lumination:shiny", new LampComposer() }
    };

    private Dictionary<string, string> features = new Dictionary<string, string>();

    public GameObject createPlayerObject() {
        GameObject playerObject = new GameObject();
        foreach (string feature in FEATURE_SEQUENCE) {
            PLAYER_COMPOSERS[feature + ":" + features[feature]].compose(playerObject);
        }
        return playerObject;
    }

    public void setFeature(string name, string value)
    {
        features[name] = value;
    }
}
