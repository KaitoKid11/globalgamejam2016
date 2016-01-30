using UnityEngine;
using System.Collections;

/// <summary>
/// Component that managers the movement of the button.
/// </summary>
public class ButtonMovement : MonoBehaviour {

    
    // Current movement of the button.
    private float _velocity;

    // The position that the button has to move to.
    private GameObject _target;

	// Use this for initialization
	void Start () {
        _target = GameObject.FindGameObjectWithTag("Target");

        _velocity = VelocityManager.Instance.getVelocity();
    }
	
	// Update is called once per frame
	void FixedUpdate () {  
        gameObject.transform.position += (_target.transform.position - gameObject.transform.position) 
            * _velocity * Time.deltaTime;
    }
}
