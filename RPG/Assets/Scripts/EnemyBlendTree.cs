using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Character enemy;
    public Animator animator;
    float state = 0.0f;
    public float chaseRadius = 6f;
    public float attackRadius = 3f;
    int StateHash;
    public GameObject player;
    public Transform _transform;

    public AudioSource hitEnemy;
    public AudioSource hurtEnemy;
    public AudioSource deadEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StateHash = Animator.StringToHash("State");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, _transform.position);

        if (distance > chaseRadius)
        {
            state = 0f;
        }
        if (distance <= chaseRadius)
        {
            state = 0.25f;
        }
        if (distance <= attackRadius)
        {
            hitEnemy.Play();
            state = 0.5f;
        }
        if (enemy.health < 50f)
        {
            hurtEnemy.Play();
            state = 0.75f;
        }
        if (enemy.health <= 0)
        {
            state = 1;

            deadEnemy.Play();
            StartCoroutine(DestroyEnemy());
        }

        animator.SetFloat(StateHash, state);
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}