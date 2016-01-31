using UnityEngine;
using System.Collections;

public class GameState : Singleton<GameState>
{
    #region GameState Attributes
    private GameObject _ranking;
    private GameObject _menu;
    private GameObject _pause;
    private GameObject _gameOver;
    private GameObject _countdown;
    private GameObject _three;
    private GameObject _two;
    private GameObject _one;
    private GameObject _guru;
    private bool _menuOn;
    private bool _pauseOn;
    private bool _gameOverOn;
    private bool _countdownEnded;
    private Vector3 _finalPos;

    private int _numSpawned;

    private bool _countdownOn3;
    private bool _countdownOn2;
    private bool _countdownOn1;

    private GAME_STATES _current; 

    public enum GAME_STATES
    {
        GAME_STATE_START,
        GAME_STATE_MENU, 
        GAME_STATE_PLAY,
        GAME_STATE_GAME_OVER,
    }
    #endregion

    #region GameState Methods
    void Start()
    {
        DontDestroyOnLoad(this);
        GameState.Instance.changeState(GAME_STATES.GAME_STATE_START);
    }

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
            case GAME_STATES.GAME_STATE_GAME_OVER:
                updateGameOver();
                break;
        }
	}

    private void updateStart() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MusicManagerGlobal.Instance.stopMusic();
            MusicManagerGlobal.Instance._selectedArray = 1;
            MusicManagerGlobal.Instance.playMusic(MusicManagerGlobal.Instance._currentMusic, MusicManagerGlobal.Instance._selectedArray);
            while (MusicManagerGlobal.Instance.gameObject.GetComponent<AudioSource>().isPlaying) { }

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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                changeState(GAME_STATES.GAME_STATE_PLAY);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                _menu.SetActive(false);
                _menuOn = false;
                _ranking.SetActive(true);
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                _ranking.SetActive(false);
                _menu.SetActive(true);
                _menuOn = true;
            }
        }
    }
    private void updatePlay() 
    {
        if (_pause == null &&_countdown == null)
        {
            _pause = GameObject.Find("PauseMenuCanvas");
            _pause.SetActive(false);
            _countdown = GameObject.Find("CountdownCanvas");
            _countdown.SetActive(false);
            foreach (Transform child in _countdown.transform)
                foreach (Transform child2 in child.transform)
                {
                    if (child2.ToString() == "One (UnityEngine.RectTransform)")
                        _one = child2.gameObject;
                    if (child2.ToString() == "Two (UnityEngine.RectTransform)")
                        _two = child2.gameObject;
                    if (child2.ToString() == "Three (UnityEngine.RectTransform)")
                        _three = child2.gameObject;
                }
            _two.SetActive(false);
            _one.SetActive(false);
        }

        if (_countdownEnded)
        {
            //BROADCAST
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
            {
                button.SendMessage("countdownOver");
            }
            _countdownEnded = false;
        }

        if (_countdownOn3)
        {
            float _time1 = Time.realtimeSinceStartup;
            float _time2 = Time.realtimeSinceStartup;
            while (_time2 - _time1 < 0.5)
            {
                _time2 = Time.realtimeSinceStartup;
            }
            _three.SetActive(false);
            _two.SetActive(true);
            _countdownOn3 = false;
            _countdownOn2 = true;
        }
        else if(_countdownOn2)
        {
            float _time1 = Time.realtimeSinceStartup;
            float _time2 = Time.realtimeSinceStartup;
            while (_time2 - _time1 < 0.5)
            {
                _time2 = Time.realtimeSinceStartup;
            }
            _two.SetActive(false);
            _one.SetActive(true);
            _countdownOn2 = false;
            _countdownOn1 = true;
        }
        else if (_countdownOn1)
        {
            float _time1 = Time.realtimeSinceStartup;
            float _time2 = Time.realtimeSinceStartup;
            while (_time2 - _time1 < 0.5)
            {
                _time2 = Time.realtimeSinceStartup;
            }
            _three.SetActive(true);
            _one.SetActive(false);
            _countdown.SetActive(false);
            _countdownOn1 = false;
            Time.timeScale = 1;
            _countdownEnded = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_pauseOn)
            {
                Time.timeScale = 0;
                _pause.SetActive(true);
                _pauseOn = true;
            }
            else
            {
                changeState(GameState.GAME_STATES.GAME_STATE_MENU);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && _pauseOn)
        {
            //BROADCAST
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
            {
                button.SendMessage("countdownStart");
            }
            Time.timeScale = 0.01f;
            _pause.SetActive(false);
            _pauseOn = false;
            _countdown.SetActive(true);
            _countdownOn3 = true;
        }

        if (_numSpawned == 20)
        {

        }
    }
    private void updateGameOver() 
    {
        if (_gameOver == null)
        {
            _gameOver = GameObject.Find("DeadMenuCanvas");
            _gameOver.SetActive(true);
            foreach (Transform child in _gameOver.transform)
                foreach (Transform child2 in child.transform)
                {
                    if (child2.ToString() == "Guru (UnityEngine.RectTransform)")
                        _guru = child2.gameObject;
                }
            _guru.transform.position += new Vector3(1.5f, 0, 0);
        }
        else
        {
            _gameOver.SetActive(true);
            if (_guru.transform.position.x <= 280)
            {
                _guru.transform.position += new Vector3(1.5f, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            changeState(GAME_STATES.GAME_STATE_PLAY);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changeState(GameState.GAME_STATES.GAME_STATE_MENU);
            Time.timeScale = 1;
        }
    }

    public void changeState(GAME_STATES nextState) 
    { 
        _current = nextState;
        switch (nextState)
        {
            case GAME_STATES.GAME_STATE_START:
                if (_current == null)
                {
                    _current = GAME_STATES.GAME_STATE_START;
                }
                break;
            case GAME_STATES.GAME_STATE_MENU:
                Application.LoadLevel("MENU");
                _menuOn = true;
                break;
            case GAME_STATES.GAME_STATE_PLAY:
                Application.LoadLevel("PLAY");
                _pauseOn = false;
                _gameOverOn = false;
                _numSpawned = 0;
                if(_pause != null){
                    _pause.SetActive(false);
                }
                if (_countdown != null)
                {
                    _countdown.SetActive(false);
                }
                break;
            case GAME_STATES.GAME_STATE_GAME_OVER:
                Application.LoadLevel("GAMEOVER");
                break;
        }
    }

    public void addSpawned()
    {
        _numSpawned += 1;
    }
    #endregion
}
