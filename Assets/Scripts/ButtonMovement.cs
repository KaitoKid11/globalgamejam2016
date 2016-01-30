using UnityEngine;
using System.Collections;

public class ButtonMovement : MonoBehaviour {

    public float _velocity;

    private GameObject _target;

    private Rigidbody2D _body;

	// Use this for initialization
	void Start () {
        _target = GameObject.FindGameObjectWithTag("Target");

        _velocity = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate () {  
        gameObject.transform.position += (_target.transform.position - gameObject.transform.position) 
            * _velocity * Time.deltaTime;
    }
}
