using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    public static GameManager instance = null;
    private GAME_STATES _current; 

    public enum GAME_STATES
    {
        GAME_STATE_MENU, 
        GAME_STATE_PLAY,
        GAME_STATE_GAME_OVER,
        GAME_STATE_PAUSE
    }
	
	// Update is called once per frame
	void Update () {
	    switch(_current)
        {
            case GAME_STATES.GAME_STATE_MENU:
                updateMenu();
                break;
            case GAME_STATES.GAME_STATE_PLAY:
                updatePlay();
                break;
            case GAME_STATES.GAME_STATE_PAUSE:
                updatePause();
                break;
            case GAME_STATES.GAME_STATE_GAME_OVER:
                updateGameOver();
                break;
        }
	}

    // Update Methods
    private void updateMenu() { }
    private void updatePlay() { }
    private void updatePause() { }
    private void updateGameOver() { }

    // State changes
    private void changeState(GAME_STATES nextState) { _current = nextState; }
}
