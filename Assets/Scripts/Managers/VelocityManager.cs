﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Manages the velocity that must have the button when launched.
/// </summary>
public class VelocityManager : Singleton<VelocityManager> {

    [System.Serializable]
    public struct Pair
    {
        [SerializeField]
        public float time;
        [SerializeField]
        public float velocity;
        [SerializeField]
        public Movement movement;
    }

    // Velocity that the buttons have when launched
    private float _velocity;

    // Current button movement
    private Movement _movement;

    // Array that has a pair time velocity
    [SerializeField]
    public Pair[] _timeVelocityArray;

    //The index that indicates the current pair from the array
    private int _currentVelocityIndex;

	// Use this for initialization
	void Start () {
        _currentVelocityIndex = 0;
        //DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log("Time: " + Time.time + " Velocity: " + _velocity);

        if(_currentVelocityIndex < _timeVelocityArray.Length)
        {
            //Change velocity
            if (_timeVelocityArray[_currentVelocityIndex].time < Time.time)
            {
                _velocity = _timeVelocityArray[_currentVelocityIndex].velocity;
                _movement = _timeVelocityArray[_currentVelocityIndex].movement;
                ++_currentVelocityIndex;
            }
        } 
    }

    /// <summary>
    /// Get the velocity.
    /// </summary>
    /// <returns></returns>
    public float getVelocity()
    {
        return _velocity;
    }

    /// <summary>
    /// Get the button movement.
    /// </summary>
    /// <returns></returns>
    public Movement getMovement()
    {
        return _movement;
    }
}
