using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void restartGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void quitGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
