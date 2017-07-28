using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public static string[] FEATURE_SEQUENCE = { "shape", "size", "color", "character", "lumination" };

    private static Dictionary<string, PlayerComposer> PLAYER_COMPOSERS = new Dictionary<string, PlayerComposer>()
    {
        { "shape:cube", new CubeComposer() },
        { "shape:ball", new BallComposer() },
        { "size:m", new SizeComposer(1) },
        { "color:yellow", new ColorComposer(null) },
        { "character:lazy", new EmptyComposer() },
        { "lumination:none", new EmptyComposer() }
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
