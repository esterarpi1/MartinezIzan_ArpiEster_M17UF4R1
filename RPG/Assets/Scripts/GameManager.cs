using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Animator _animator;

    public int objectsToBeFound = 3;

    public GameObject _mainCamera;
    public GameObject _miniMapCamera;
    public GameObject _fpCamera;

    public AudioSource changeCamera;
    public AudioSource gotAllObjects;

    bool alreadyPlayed = false;


    //Classes to get the data stored in the json
    [Serializable]
    public class PlayerData
    {
        public float positionX { get; set; }
        public float positionY { get; set; }
        public float positionZ { get; set; }
        public float health { get; set; }
        public string[] inventoryItems { get; set; }

        public PlayerData(float positionX, float positionY, float positionZ, float health, string[] inventoryItems)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.health = health;
            this.inventoryItems = inventoryItems;
        }
    }

    PlayerData playerData;

    private void Awake()
    {
        try
        {
            //Read the json file
            StreamReader sr = File.OpenText("./Assets/Scripts/Data.json");
            string content = sr.ReadToEnd();
            sr.Close();
            playerData = JsonUtility.FromJson<PlayerData>(content);
            //if (playerData.playerInventory.items.Length > 0) InventoryItems.Instance.checkInventory(playerData.playerInventory.items);
            //MainPlayer.Instance.setPlayer(playerData.positionX, playerData.positionY, playerData.positionZ, playerData.health);
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    public void saveData()
    {
        //Update player data at this time
        playerData.positionX = MainPlayer.Instance._transform.position.x;
        playerData.positionY = MainPlayer.Instance._transform.position.y;
        playerData.positionZ = MainPlayer.Instance._transform.position.z;
        playerData.health = MainPlayer.Instance.player.health;
        //string[] inventory = Inventory.instance.getCurrentInventory();
        //playerData.inventoryItems = inventory;
        Debug.Log(playerData);
        try
        {
            StreamWriter sw = new StreamWriter("./Assets/Scripts/Data.json");
            string json = JsonUtility.ToJson(playerData, true);
            sw.WriteLine(json);
        } catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Singeton to make sure that we don't duplicate the gamemanager
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else Destroy(gameObject);

        InputController.MiniMap += miniMap;
        InputController.ChangeCamera += cameraController;
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
    {
        if (_fpCamera.activeSelf == true)
        {
            _miniMapCamera.SetActive(false);
            _fpCamera.SetActive(false);
            _mainCamera.SetActive(true);
        }
        else
        {
            _miniMapCamera.SetActive(false);
            _fpCamera.SetActive(true);
            _mainCamera.SetActive(false);
            changeCamera.Play();
        }
    }
}
