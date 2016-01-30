using UnityEngine;
using System.Collections;

public class ButtonDetection : Singleton<ButtonDetection> {

    public void buttonDown(GameObject button)
    {
        if (button.GetComponent<Buttons>()._inDetection)
        {
            if (button.GetComponent<Buttons>()._inDeath && button.GetComponent<Buttons>()._inDeathAux)
            {

            }
            else
            {
                //LLAMAR A MANAGER PUNTUACIÓN Y AÑADIR PUNTOS
                Destroy(button);
            }
        }
    }
}
