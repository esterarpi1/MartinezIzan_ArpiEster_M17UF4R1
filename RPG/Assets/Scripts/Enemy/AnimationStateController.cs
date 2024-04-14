using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;
    float state = 0.0f;
    public float chaseRadius = 6f;
    public float attackRadius = 3f;
    public float health = 100f;
    int StateHash;

    // Start is called before the first frame update
    void Start()
    {
        StateHash = Animator.StringToHash("State");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(MainPlayer.Instance.transform.position, transform.position);

        if(distance > chaseRadius)
        {
            state = 0f;
        }
        if (distance <= chaseRadius)
        {
            state = 0.25f;
        }
        if (distance <= attackRadius)
        {
            state = 0.5f;
        }
        if (health < 50f)
        {
            state = 0.75f;
        }
        if(health <= 0)
        {
            state = 1;
        }

        animator.SetFloat(StateHash, state);
    }
}
