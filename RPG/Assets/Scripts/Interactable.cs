using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractable : MonoBehaviour
{
    public float radius = 3f;
    public bool isFocus = false;
    public bool hasInteracted = false;

    public virtual void Interact()
    {

    }
    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(MainPlayer.Instance.transform.position, transform.position);
            if (distance <= radius)
            {
            
                Interact();
                hasInteracted = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
