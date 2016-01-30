using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the button generation.
/// </summary>
public class ButtonGenerator : Singleton<ButtonGenerator> {

    private enum Side
    {
        Left,
        Right
    }

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

    //Prefab to launch
    public GameObject _launchButton;

    //The velocity which the generated buttons must have
    public float _velocity;

    // Use this for initialization
    void Start () {
        _upLeft = GameObject.FindGameObjectWithTag("UpLeft");
        _downLeft = GameObject.FindGameObjectWithTag("DownLeft");
        _upRight = GameObject.FindGameObjectWithTag("UpRight");
        _downRight = GameObject.FindGameObjectWithTag("DownRight");

        _target = GameObject.FindGameObjectWithTag("Target");

        _random = new System.Random();

        _acumulatedTime = _spawnTime;
    }
	
	/// <summary>
    /// Checks if a button has to be generated.
    /// </summary>
	void Update () {
        //Debug.Log(generateRandomNumber(_upLeft.transform.position.y,_downLeft.transform.position.y));

        if(_acumulatedTime < Time.time)
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

        if ((Side)side == Side.Left)
        {
            double auxPosition = generateRandomNumber(_upLeft.transform.position.y, _downLeft.transform.position.y);
            Vector3 positionLaunch = new Vector3(_upLeft.transform.position.x, (float)auxPosition, 0);
            GameObject button = (GameObject)Instantiate(_launchButton, positionLaunch, Quaternion.identity);
        }
        else
        {
            double auxPosition = generateRandomNumber(_upRight.transform.position.y, _downRight.transform.position.y);
            Vector3 positionLaunch = new Vector3(_upRight.transform.position.x, (float)auxPosition, 0);
            GameObject button = (GameObject)Instantiate(_launchButton, positionLaunch, Quaternion.identity);
            button.GetComponent<ButtonMovement>()._velocity = _velocity;
        }
    } 
}
