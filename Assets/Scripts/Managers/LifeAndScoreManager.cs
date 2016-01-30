using UnityEngine;
using System.Collections;

public class LifeAndScoreManager : Singleton<LifeAndScoreManager>
{
    public int _playerLife;
    public float _playerScore;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(_playerLife <= 0)
        {
            GameState.Instance.changeState(GameState.GAME_STATES.GAME_STATE_GAME_OVER);
        }
	}

    public void inflictDamage(GameObject button)
    {
        _playerLife -= button.GetComponent<Buttons>()._damage;
        Destroy(button);
    }
}
