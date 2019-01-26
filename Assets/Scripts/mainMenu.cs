using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public void goToScene(string sceneName){
        Application.LoadLevel(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
