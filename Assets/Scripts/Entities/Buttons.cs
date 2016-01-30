using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

    public enum BUTTONS_TO_PUSH
    {
        W, A, S, D, UpArrow, DownArrow, LeftArrow, RightArrow
    }

    [HideInInspector]
    public bool _inDetection;
    [HideInInspector]
    public bool _inDeath;
    [HideInInspector]
    public bool _inDeathAux;
    [HideInInspector]
    public bool _fail;

    public GameObject _target;
    public int _maxKeys;

    public Sprite W;
    public Sprite A;
    public Sprite S;
    public Sprite D;
    public Sprite Up;
    public Sprite Left;
    public Sprite Down;
    public Sprite Right;

    //PARA FUTURAS PRUEBAS DE DESARROLLADORES
    public int _damage = 10;
    //public int _speed;
    

    private System.Random _random;
    private int _speed;
    private KeyCode _buttonToPush;

	// Use this for initialization
    void Start()
    {
        _inDetection = false;
        _inDeath = false;
        _inDeathAux = false;
        _random = new System.Random();
        _buttonToPush = buttonEnumToKeyCode((BUTTONS_TO_PUSH)_random.Next(0, _maxKeys - 1));
        setSpriteToButton(_buttonToPush);
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_buttonToPush))
        {
            ButtonDetection.Instance.buttonDown(gameObject);
        }
        if (_fail)
        {
            doDamage();
            _fail = false;
        }
	}

    void OnTriggerEnter2D(Collider2D zone)
    {
        switch (zone.gameObject.name)
        {
            case "DetectionZone":
                _inDetection = true;
                break;
            case "DeathZone":
                _inDeath = true;
                break;
            case "DeathAuxZone":
                _inDeathAux = true;
                break;
            case "Target":
                _fail = true;
                break;
        }
    }

    public void doDamage()
    {
        LifeAndScoreManager.Instance.inflictDamage(gameObject);
    }

    private KeyCode buttonEnumToKeyCode(BUTTONS_TO_PUSH button)
    {
        switch (button)
        {
            case BUTTONS_TO_PUSH.W:
                return KeyCode.W;
            case BUTTONS_TO_PUSH.A:
                return KeyCode.A;
            case BUTTONS_TO_PUSH.S:
                return KeyCode.S;
            case BUTTONS_TO_PUSH.D:
                return KeyCode.D;
            case BUTTONS_TO_PUSH.UpArrow:
                return KeyCode.UpArrow;
            case BUTTONS_TO_PUSH.DownArrow:
                return KeyCode.DownArrow;
            case BUTTONS_TO_PUSH.LeftArrow:
                return KeyCode.LeftArrow;
            case BUTTONS_TO_PUSH.RightArrow:
                return KeyCode.RightArrow;
        }
        return KeyCode.PageDown;
    }
    private void setSpriteToButton(KeyCode button)
    {
        switch(button)
        {
            case KeyCode.W:
                gameObject.GetComponent<SpriteRenderer>().sprite = W;
                break;
            case KeyCode.A:
                gameObject.GetComponent<SpriteRenderer>().sprite = A;
                break;
            case KeyCode.S:
                gameObject.GetComponent<SpriteRenderer>().sprite = S;
                break;
            case KeyCode.D:
                gameObject.GetComponent<SpriteRenderer>().sprite = D;
                break;
            case KeyCode.UpArrow:
                gameObject.GetComponent<SpriteRenderer>().sprite = Up;
                break;
            case KeyCode.LeftArrow:
                gameObject.GetComponent<SpriteRenderer>().sprite = Left;
                break;
            case KeyCode.DownArrow:
                gameObject.GetComponent<SpriteRenderer>().sprite = Down;
                break;
            case KeyCode.RightArrow:
                gameObject.GetComponent<SpriteRenderer>().sprite = Right;
                break;
        }
    }
}
