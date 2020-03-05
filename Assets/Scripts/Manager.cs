using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public int coins = 0;
    private GUIStyle gui = new GUIStyle();

    void OnGUI()
    {
        //esto aumenta el tamaño del score en la pantalla
        gui.fontSize = 30;

        //esto muestra cuantas monedas a recolectado el objeto
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + coins, gui);


    }
    //funcion que reinicia la escena 
    public void gameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}