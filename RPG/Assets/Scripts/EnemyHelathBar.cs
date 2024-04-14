using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHelathBar : MonoBehaviour
{
    public Character enemy;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.enabled = true;
        healthBar.maxValue = enemy.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = enemy.health;
    }
}
