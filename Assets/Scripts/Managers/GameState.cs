using UnityEngine;
using System.Collections;

public class GameState : Singleton<GameState>
{
    public static GameState instance = null;
    private GAME_STATES _current; 

    public enum GAME_STATES
    {
        GAME_STATE_START,
        GAME_STATE_MENU, 
        GAME_STATE_PLAY,
        GAME_STATE_GAME_OVER,
        GAME_STATE_PAUSE
    }
	
	// Update is called once per frame
	void Update () {
	    switch(_current)
        {
            case GAME_STATES.GAME_STATE_START:
                updateStart();
                break;
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
    private void updateStart() { }
    private void updateMenu() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            changeState(GAME_STATES.GAME_STATE_START);
            Application.LoadLevel("START");  
        }
    }
    private void updatePlay() { }
    private void updatePause() { }
    private void updateGameOver() { }

    // State changes
    public void changeState(GAME_STATES nextState) 
    { 
        _current = nextState;
        switch (nextState)
        {
            case GAME_STATES.GAME_STATE_START:

                break;
            case GAME_STATES.GAME_STATE_MENU:
                
                break;
            case GAME_STATES.GAME_STATE_PLAY:
                Application.LoadLevel("PLAY");
                break;
            case GAME_STATES.GAME_STATE_PAUSE:

                break;
            case GAME_STATES.GAME_STATE_GAME_OVER:

                break;
        }
    }
}
