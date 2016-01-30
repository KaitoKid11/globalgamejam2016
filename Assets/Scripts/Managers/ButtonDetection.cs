using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonDetection : Singleton<ButtonDetection> {

    private GameObject _comboNumberText;

    private int _combo;

    void Start()
    {
        _comboNumberText = GameObject.FindGameObjectWithTag("ComboNumberText");

        _combo = 0;
    }

    public void buttonDown(GameObject button)
    {
        if (button.GetComponent<Buttons>()._inDetection)
        {
            if (button.GetComponent<Buttons>()._inDeath && button.GetComponent<Buttons>()._inDeathAux)
            {

            }
            else
            {
                ++_combo;
                _comboNumberText.GetComponent<Text>().text = _combo.ToString();
                //LLAMAR A MANAGER PUNTUACIÓN Y AÑADIR PUNTOS
                Destroy(button);
            }
        }
    }
}
