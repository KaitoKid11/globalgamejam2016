using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startButton()
    {
        GameState.Instance.changeState(GameState.GAME_STATES.GAME_STATE_PLAY);
    }
}
