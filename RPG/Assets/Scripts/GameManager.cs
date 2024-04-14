using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text UItext;
    void Start()
    {
        if (gm != null && gm != this)
            Destroy(this.gameObject);
        gm = this;
        DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Checks whether the player has found all 3 objects
        if (objectsToBeFound == 0 && !alreadyPlayed)
        {
            _animator.SetBool("isDancing", true);
            gotAllObjects.Play();
            alreadyPlayed = true;
            StartCoroutine(StopDancing());
        }
    }
    IEnumerator StopDancing()
    {
        yield return new WaitForSeconds(3);
        _animator.SetBool("isDancing", false);
    }

    //Camera controller to set the minimap view
    public void miniMap()
    {
        if (_miniMapCamera.activeSelf == true)
        {
            _miniMapCamera.SetActive(false);
            _fpCamera.SetActive(false);
            _mainCamera.SetActive(true);
        }
        else
        {
            _miniMapCamera.SetActive(true);
            _fpCamera.SetActive(false);
            _mainCamera.SetActive(false);
            changeCamera.Play();
        }
    }

    //Camera controller to set the first or third person camera
    public void cameraController()
    public void UpdateText(string text)
    {
        UItext.text = text;        
    }
}
