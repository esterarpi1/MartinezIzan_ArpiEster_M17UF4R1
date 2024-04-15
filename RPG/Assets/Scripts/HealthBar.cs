using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Character Player;
    public Slider healthBar;
    private bool isCollidingWithEnemy = false; // Variable para controlar si el jugador está en contacto con un enemigo

    void Start()
    {
        healthBar.enabled = true;
        healthBar.maxValue = Player.maxHealth;
        Player.health = Player.maxHealth;
    }

    void Update()
    {
        // Si el jugador está en contacto con un enemigo, disminuir la salud continuamente
        if (isCollidingWithEnemy)
        {
            Player.health -= 40 * Time.deltaTime; // Disminuir la salud en 10 puntos por segundo
            healthBar.value = Player.health;

            // Verificar si la salud ha alcanzado 0 o menos
            if (Player.health <= 0)
            {
                // Aquí puedes agregar código para manejar la muerte del jugador, como reiniciar el nivel o mostrar un mensaje de game over
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isCollidingWithEnemy = true; // Indicar que el jugador está en contacto con un enemigo
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            isCollidingWithEnemy = false; // Indicar que el jugador ya no está en contacto con un enemigo
        }
    }
}
