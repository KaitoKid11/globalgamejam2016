using UnityEngine;
using System.Collections;

/// <summary>
/// Enum that indicates on which side on the screen the button is generated.
/// </summary>
public enum Side
{
    Left,
    Right
}

/// <summary>
/// Manages the button generation.
/// </summary>
public class ButtonGenerator : Singleton<ButtonGenerator> {

    //Reference points to genereate the position of the buttons.
    private GameObject _upLeft;
    private GameObject _downLeft;
    private GameObject _upRight;
    private GameObject _downRight;

    //Target
    private GameObject _target;

    //Random Object Generator
    private System.Random _random;

    //Time interval spawn
    [SerializeField]
    private float _spawnTime;
    //Acumulated time
    private float _acumulatedTime = 0;
    //Time when the scene was activated
    private float _timeZero;

    //Prefab to launch
    public GameObject _launchButton;

    //Indicates if the generator must generate buttons
    private bool _isActive;

    //Property to change the active status
    public bool Active
    {
        get
        {
            return _isActive;
        }

        set
        {
            if(value == true)
            {
                _acumulatedTime = Time.time + _spawnTime;
            }

            _isActive = value;
        }
    }

    //Indicates when to launch one side force launch
    [SerializeField]
    private int _maxOneSideCounter;

    //Indicates how many times a button has spawned in one side
    private int _currentSideCounter;

    //The previous side launch
    private Side _previousSide;

    // Use this for initialization
    void Start () {
        _upLeft = GameObject.FindGameObjectWithTag("UpLeft");
        _downLeft = GameObject.FindGameObjectWithTag("DownLeft");
        _upRight = GameObject.FindGameObjectWithTag("UpRight");
        _downRight = GameObject.FindGameObjectWithTag("DownRight");

        _target = GameObject.FindGameObjectWithTag("Target");

        _random = new System.Random();

        _acumulatedTime = _spawnTime;

        _currentSideCounter = 0;

        _isActive = true;

        _timeZero = Time.time;
    }
	
	/// <summary>
    /// Checks if a button has to be generated.
    /// </summary>
	void Update () {
        //Debug.Log(generateRandomNumber(_upLeft.transform.position.y,_downLeft.transform.position.y));

        if(_isActive & _acumulatedTime < (Time.time - _timeZero))
        {
            generateButton();
            _acumulatedTime += _spawnTime;
        }
	}


    private double generateRandomNumber(double y1, double y2)
    {
        return _random.NextDouble() * (y2 - y1) + y1;
    }

    /// <summary>
    /// Generates the side where the button is going to be launched. 
    /// Generate the button in a "pseudo" position depending on the side.
    /// </summary>
    private void generateButton()
    {
        //Generate a side where the button is going to be thrown (0 or 1)
        // 0 -> Left
        // 1 -> Right
        int side = _random.NextDouble() >= 0.5 ? 1 : 0;

        Side currentSide = (Side)side;

        //Debug.Log("Side: " + currentSide + " Previous side: " + _previousSide);
        //Debug.Log("Current Side Counter: " + _currentSideCounter + " Max Current Side Counter: " + _maxOneSideCounter);

        //Check if the thrown side is the same as before
        if (currentSide == _previousSide)
        {
            _currentSideCounter++;

            if (_currentSideCounter > _maxOneSideCounter)
            {
                //Swap side

                if (currentSide == Side.Left)
                    currentSide = Side.Right;
                else if(currentSide == Side.Right)
                    currentSide = Side.Left;

                _currentSideCounter = 0;
            }
        }

        //Launch the button depending on the side

        if (currentSide == Side.Left)
        {
            double auxPosition = generateRandomNumber(_upLeft.transform.position.y, _downLeft.transform.position.y);
            Vector3 positionLaunch = new Vector3(_upLeft.transform.position.x, (float)auxPosition, 0);
            GameObject button = (GameObject)Instantiate(_launchButton, positionLaunch, Quaternion.identity);
            button.GetComponent<ButtonMovement>().setButtonSide(currentSide);
        }
        else
        {
            double auxPosition = generateRandomNumber(_upRight.transform.position.y, _downRight.transform.position.y);
            Vector3 positionLaunch = new Vector3(_upRight.transform.position.x, (float)auxPosition, 0);
            GameObject button = (GameObject)Instantiate(_launchButton, positionLaunch, Quaternion.identity);
            button.GetComponent<ButtonMovement>().setButtonSide(currentSide);
        }

        _previousSide = currentSide;
    } 

    /// <summary>
    /// Start to spawn buttons.
    /// </summary>
    public void startSpawn()
    {
        _isActive = true;
    }

    /// <summary>
    /// Stop to spawn buttons.
    /// </summary>
    public void stopSpawn()
    {
        _isActive = true;
    }
}
