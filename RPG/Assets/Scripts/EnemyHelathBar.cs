using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHelathBar : MonoBehaviour
{
    public Character enemy;
    public Slider healthBar;

    void Start()
    {
        healthBar.enabled = true;
        healthBar.maxValue = enemy.maxHealth;
        enemy.health = enemy.maxHealth;
    }

    void Update()
    {
        healthBar.value = enemy.health;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisionó tiene el tag "bullet"
        if (other.gameObject.CompareTag("bullet"))
        {
            // Reducir la salud del enemigo en 10 puntos
            enemy.health -= 10;

            // Actualizar el valor de la barra de salud
            healthBar.value = enemy.health;

            // Destruir el objeto que disparó (la bala)
            Destroy(other.gameObject);
        }
    }
}
