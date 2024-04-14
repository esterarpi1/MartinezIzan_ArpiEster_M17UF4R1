using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Click(int n)
    {
        if(n == -1) Application.Quit();
        else SceneManager.LoadScene(n);
    }
}
