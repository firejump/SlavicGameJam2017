using System.Collections.Generic;
using UnityEngine;

public class PlayerState {
    public static string[] FEATURE_SEQUENCE = { "shape", "color", "lumination", "size", "character" };

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

    public static List<KeyValuePair<string, string>> getFeaturesAndValues() {
        List < KeyValuePair<string, string> > list = new List<KeyValuePair<string, string>>();
        foreach (string feature in PLAYER_COMPOSERS.Keys) {
            string[] featureValue = feature.Split(':');
            list.Add(new KeyValuePair<string, string>(featureValue[0], featureValue[1]));
        }
        return list;
    }

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

    public bool checkFeature(string name, string value)
    {
        return features[name] == value;
    }
}
