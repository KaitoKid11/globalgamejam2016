using UnityEngine;
using System.Collections;

public class MusicManagerEffects : Singleton<MusicManagerEffects> {

    public AudioClip [] _globalMusic;
    public AudioClip [] _effects;

    public int _currentMusic;

    public int _selectedArray;
    // 0 -> global, 1 -> _effects

    public bool _random;

    // Use this for initialization
    void Start () {
        _currentMusic = 0;
        _selectedArray = 0;

        int idMusic = 0;

        if (_random)
            idMusic = new System.Random().Next(0, _globalMusic.Length - 1);

        if(_selectedArray == 0)
            playMusic(_currentMusic, idMusic);
    }
	
    public void playMusic(int musicId, int selectedArray)
    {
        if(_selectedArray == 0)
        {
            GetComponent<AudioSource>().clip = _globalMusic[_currentMusic];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().clip = _effects[_currentMusic];
            GetComponent<AudioSource>().Play();
        }
    }

    public void stopMusic()
    {
        GetComponent<AudioSource>().Stop();
    } 
}
