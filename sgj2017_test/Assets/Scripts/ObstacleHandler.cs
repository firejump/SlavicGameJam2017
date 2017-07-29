using System;
using UnityEngine;

public abstract class ObstacleHandler
{
    public abstract bool check();
    public abstract void onHit();
}

public class RavineHandler : ObstacleHandler {
    public override bool check()
    {
        return GameState.getInstance().getPlayerState().checkFeature("size", "l");
    }
    public override void onHit() { }
}

public class FlowerHandler : ObstacleHandler
{
    public override bool check()
    {
        return !GameState.getInstance().getPlayerState().checkFeature("color", "green");
    }
    public override void onHit() {
        GameObject.FindWithTag("mushroomAnimator").GetComponent<Animator>().SetBool("killing", true);
    }
}

public class SlopeHandler : ObstacleHandler
{
    public override bool check()
    {
        PlayerState state = GameState.getInstance().getPlayerState();
        return !(state.checkFeature("shape", "ball") || state.checkFeature("character", "energetic"));
    }
    public override void onHit() { }
}