using UnityEngine;
using System.Collections;

/// <summary>
/// Enum that indicates the movement of the button.
/// </summary>
public enum Movement
{
    Linear,
    Curve,
    Sin,
    Segment
}


/// <summary>
/// Component that managers the movement of the button.
/// </summary>
public class ButtonMovement : MonoBehaviour {    
    // Current movement of the button.
    private float _velocity;

    // Angle for circular ecuation.
    private float _angle;

    // Amplitude for sin movement
    [SerializeField]
    private float _sinAmpltude;

    //Phase for sin movement
    [SerializeField]
    private float _sinFase;

    // The position that the button has to move to.
    private GameObject _target;

    // The side on which the button is going to be generated.
    private Side _side;

    // The current movement trayectory.
    private Movement _currentMovement;

	// Use this for initialization
	void Start () {
        _target = GameObject.FindGameObjectWithTag("Target");

        _velocity = VelocityManager.Instance.getVelocity();

        _currentMovement = VelocityManager.Instance.getMovement();

        _sinAmpltude = 5.0f;

        _sinFase = 3.0f;

        _angle = 0;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 direction;

        if(_currentMovement == Movement.Sin)
        {
            direction = new Vector3(Time.time, _sinAmpltude * Mathf.Sin(Time.time * _sinFase), 0);

            //Change trayectory direction
            if (_side == Side.Right)
                direction *= -1;

            gameObject.transform.position += direction
                * _velocity * Time.deltaTime;
        }
        else if(_currentMovement == Movement.Linear)
        {
            gameObject.transform.position += (_target.transform.position - gameObject.transform.position)
            * _velocity * Time.deltaTime;
        }
        else if(_currentMovement == Movement.Curve)
        {
            /*
            //Calculate X
            float xAux = (gameObject.transform.position.x + _target.transform.position.x) / 2;

            //Calculate Y
            float yAux = (gameObject.transform.position.y + _target.transform.position.y) / 2;

            //Radius
            float radius = Mathf.Sqrt(
                (Mathf.Pow(gameObject.transform.position.x + _target.transform.position.x, 2) +
                Mathf.Pow(gameObject.transform.position.y + _target.transform.position.y, 2)
                ))/2;

        
            _angle += Time.deltaTime; //if you want to switch direction, use -= instead of +=
            float x = Mathf.Cos(_angle) * radius + xAux;
            float y = Mathf.Sin(_angle) * radius + yAux;

            gameObject.transform.position = new Vector3(x, y, 0);
            */
        }
    }

    /// <summary>
    /// Sets the side.
    /// </summary>
    /// <param name="side"> the new side.</param>
    public void setButtonSide(Side side)
    {
        _side = side;
    }
}
