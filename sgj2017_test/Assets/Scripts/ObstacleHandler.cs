using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class ObstacleHandler {
    public abstract bool check();
    public abstract void onHit(MonoBehaviour obstacle);

    // prevent multiple triggering
    public static bool EXPLODED = false;

    /**
     * Helper method to make player explosion animation
     */
    private static IEnumerator explodeDelayed() {
        yield return new WaitForSeconds(0.3f);
        GameObject actualPlayer = GameObject.FindGameObjectsWithTag("Player")[0];
        ParticleExploderScript.Explode(actualPlayer, actualPlayer.GetComponent<Transform>().position);
        GameObject.Destroy(actualPlayer);
    }
    public static void explodePlayer(MonoBehaviour obstacle) {
        if (!EXPLODED) {
            EXPLODED = true;
            obstacle.StartCoroutine(explodeDelayed());

        }
    }
}

public class RavineHandler : ObstacleHandler {
    public override bool check()
    {
        return GameState.getInstance().getPlayerState().checkFeature("size", "l");
    }
    public override void onHit(MonoBehaviour obstacle)
    {
        explodePlayer(obstacle);
    }
}

public class FlowerHandler : ObstacleHandler
{
    public override bool check()
    {
        Debug.Log("Flower check : " + GameState.getInstance().getPlayerState().getFeature("color") + " vs " + GameState.getInstance().getAttackerColorString());
        return !GameState.getInstance().getPlayerState().checkFeature("color", GameState.getInstance().getAttackerColorString());
    }
    public override void onHit(MonoBehaviour obstacle) {
        obstacle.GetComponentInChildren<Animator>().SetBool("killing", true);
        explodePlayer(obstacle);
    }
}

public class SlopeHandler : ObstacleHandler
{
    public override bool check()
    {
        PlayerState state = GameState.getInstance().getPlayerState();
        return !(state.checkFeature("shape", "ball") || state.checkFeature("character", "energetic"));
    }
    public override void onHit(MonoBehaviour obstacle)
    {
        // TODO use other animation
        explodePlayer(obstacle);
    }
}

public class DarknessHandler : ObstacleHandler {
    public override bool check() {
        return GameState.getInstance().getPlayerState().checkFeature("lumination", "none");
    }
    public override void onHit(MonoBehaviour obstacle) {
        explodePlayer(obstacle);
    }
}