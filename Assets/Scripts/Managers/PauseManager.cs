using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    private bool _paused;

	// Use this for initialization
	void Start () {
        _paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape) && _paused)
        {
            _paused = true;
            Time.timeScale = 0;
            //ACTIVATE PAUSE GUI
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _paused)
        {
            resumeGame();
        }
	}

    public void pauseExitButton()
    {
        GameState.Instance.changeState(GameState.GAME_STATES.GAME_STATE_MENU);
    }

    public void pauseResumeButton()
    {
        resumeGame();
    }

    private void resumeGame()
    {
        _paused = false;
        //SHOW COUNTDOWN
        //DEACTIVATE PAUSE GUI
        Time.timeScale = 1;
    }
}
