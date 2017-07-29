using System;

public abstract class ObstacleHandler
{
    public abstract bool check();
}

public class RavineHandler : ObstacleHandler {
    public override bool check()
    {
        return GameState.getInstance().getPlayerState().checkFeature("size", "l");
    }
}

public class FlowerHandler : ObstacleHandler
{
    public override bool check()
    {
        return !GameState.getInstance().getPlayerState().checkFeature("color", "green");
    }
}

public class SlopeHandler : ObstacleHandler
{
    public override bool check()
    {
        PlayerState state = GameState.getInstance().getPlayerState();
        return !(state.checkFeature("shape", "ball") || state.checkFeature("character", "energetic"));
    }
}