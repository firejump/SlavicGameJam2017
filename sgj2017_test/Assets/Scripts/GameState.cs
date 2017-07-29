public class GameState {
    private GameState() {
        playerState = new PlayerState();
        setPlayerDefaults();
    }

    private void setPlayerDefaults()
    {
        playerState.setFeature("shape", "ball");
        playerState.setFeature("size", "m");
        playerState.setFeature("color", "yellow");
        playerState.setFeature("character", "energetic");
        playerState.setFeature("lumination", "shiny");
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

    public void updatePlayerState(object slotsValues)
    {
        //TODO set player features depending on slots values
    }

    public void generateSlotsRules()
    {

    }

    private PlayerState playerState;
    private static GameState instance;
}
