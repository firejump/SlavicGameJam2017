public class GameState {
    private GameState() {
        playerState = new PlayerState();
        setPlayerDefaults();
    }

    private void setPlayerDefaults()
    {
        playerState.setFeature("shape", "cube");
        playerState.setFeature("size", "m");
        playerState.setFeature("color", "yellow");
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

    private PlayerState playerState;
    private static GameState instance;
}
