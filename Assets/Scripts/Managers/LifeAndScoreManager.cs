using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class LifeAndScoreManager : Singleton<LifeAndScoreManager>
{
    public int _playerLife;
    public float _playerScore;
    private string _name;
    private GameState _gameState;

    //Highscore File
    string _directory = "Output";
    string _fileName = "";
    StreamWriter _sr;

    //UIElements
    private GameObject _playerLifeSlider;
    private GameObject _comboNumberText;
    private GameObject _scoreNumber;

    public int _combo;

    // Use this for initialization
    void Start() {

        //Hoghscore File
        createDirectory();
        createFile();
        _playerLifeSlider = GameObject.FindGameObjectWithTag("PlayerLife");

        _comboNumberText = GameObject.FindGameObjectWithTag("ComboNumberText");

        _combo = 0;

        _playerLife = 100;
        _gameState = GameObject.Find("GameState").GetComponent<GameState>();
    }
	
	// Update is called once per frame
	void Update () {
	    if(_playerLife <= 0)
        {
            _gameState.changeState(GameState.GAME_STATES.GAME_STATE_GAME_OVER);
        }
	}

    public void inflictDamage(GameObject button)
    {
        _playerLife -= button.GetComponent<Buttons>()._damage;

        
        Slider slider = _playerLifeSlider.GetComponent<Slider>();
        slider.value = _playerLife;
        ButtonDetection.Instance._combo = 0;
        _comboNumberText.GetComponent<Text>().text = _combo.ToString();
        Destroy(button);
    }

    void createDirectory()
    {
        if (!Directory.Exists(_directory))
        {
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(_directory);
            Debug.Log("The directory " + _directory + " was created successfully." + Directory.GetCreationTime(_directory));
        }
        else
        {
            Debug.LogWarning("WARNING!! The directory " + _directory + " already exists.");
        }
    }


    StreamWriter createFile()
    {
        
        _fileName = _directory + "/highscore.txt";

        StreamWriter sr = null;

        
        //if (File.Exists(_fileName))
        //{
        //    Debug.LogWarning("WARNING!! The file " + _fileName + " already exists. Opening it.");
        //    FileStream sr1 = File.Open(_fileName, FileMode.Append,FileAccess.ReadWrite);
        //}
        //else
        //{
        //    sr = File.CreateText(_fileName);
        //    Debug.Log("The file " + _fileName + " was created successfully!!");
        //}
        
        //writeUserData("User Daniel, Score 1000");
        

        return sr;
    }

    void WriteLine(string line)
    {
        _sr.WriteLine(line);
    }

    
    void closeFile()
    {
        _sr.Close();
    }

    void writeUserData(string data)
    {
        WriteLine(data);
    }
}
