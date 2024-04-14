using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class SavePoint : IInteractable
{
    public override void Interact()
    {
        savingData();
    }
    void savingData()
    {
        Debug.Log("saving..");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
