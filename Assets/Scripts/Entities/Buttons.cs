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
    public GameObject _target;
    public int _maxKeys;
    //PARA FUTURAS PRUEBAS DE DESARROLLADORES
    //public int _speed;
    //public int _damage;

    private int _damage = 10;
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
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(_buttonToPush))
        {
            ButtonDetection.Instance.buttonDown(gameObject);
        }
	}

    void OnTriggerEnter(Collider zone)
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
        }
    }

    public void doDamage()
    {
        LifeAndScoreManager.Instance.inflictDamage(_damage);
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
}
