using UnityEngine;
using System.Collections;

public class GameState : Singleton<GameState>
{
    private GameObject _ranking;
    private GameObject _menu;
    private bool _menuOn;
    private bool _rankingOn;

    private GAME_STATES _current; 

    public enum GAME_STATES
    {
        GAME_STATE_START,
        GAME_STATE_MENU, 
        GAME_STATE_PLAY,
        GAME_STATE_GAME_OVER,
        GAME_STATE_PAUSE
    }
    void Start()
    {
        DontDestroyOnLoad(this);
        GameState.Instance.changeState(GAME_STATES.GAME_STATE_START);
        //INICIAR MÚSICA DE SCENE START
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
    private void updateStart() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.LoadLevel("MENU");
            changeState(GAME_STATES.GAME_STATE_MENU);
        }
    }
    private void updateMenu() 
    {
        if(_menu == null || _ranking == null)
        {
            _menu = GameObject.Find("MainMenuCanvas");
            _ranking = GameObject.Find("RankingCanvas");
        }
        if(_menuOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel("PLAY");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _menu.SetActive(false);
                _menuOn = false;
                _ranking.SetActive(true);
                _rankingOn = true;
                Debug.Log("Cambio realizado");
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _ranking.SetActive(false);
                _rankingOn = false;
                _menu.SetActive(true);
                _menuOn = true;
            }
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
                //CORTAR MÚSICA ACTIVA EN ESTE MOMENTO
                //INICIAR MÚSICA DE SCENE START
                break;
            case GAME_STATES.GAME_STATE_MENU:
                //CORTAR MÚSICA ACTIVA EN ESTE MOMENTO
                //INICIAR MÚSICA DE SCENE MENU
                _menuOn = true;
                _rankingOn = false;
                break;
            case GAME_STATES.GAME_STATE_PLAY:
                //INICIAR MÚSICA DE SCENE PLAY - LEVEL 1
                Application.LoadLevel("PLAY");
                break;
            case GAME_STATES.GAME_STATE_PAUSE:

                break;
            case GAME_STATES.GAME_STATE_GAME_OVER:

                break;
        }
    }
}
