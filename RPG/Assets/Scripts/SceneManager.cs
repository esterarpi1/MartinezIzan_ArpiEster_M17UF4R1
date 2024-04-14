using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Basic controller for the menus
    public void chooseScene(int n)
    {
        if (n == -1) Application.Quit();
        else SceneManager.LoadScene(n);
    }
}
