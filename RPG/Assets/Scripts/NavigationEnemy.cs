using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public Transform direction1; // Primer punto de destino
    public Transform direction2; // Segundo punto de destino
    public Transform player; // Posición del jugador
    public float chaseDistance = 10f; // Distancia a partir de la cual comienza a perseguir al jugador
    public float switchDistance = 1f; // Distancia a partir de la cual cambia de dirección/
    public Character enemyData; // Scriptable object que contiene datos del enemigo

    private NavMeshAgent agent;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination(direction1.position);
    }

    void Update()
    {
        if (enemyData.health < 50)
        {
            Vector3 fleeDirection = player.position;
            Vector3 targetDestination = transform.position + fleeDirection.normalized * 10f; // Distancia de huída
            SetDestination(targetDestination);
        }
        else
        {
            if (!isChasing)
            {
                // Si no está persiguiendo al jugador, moverse entre direction1 y direction2
                if (Vector3.Distance(transform.position, agent.destination) <= switchDistance)
                {
                    // Cambiar la dirección de destino entre direction1 y direction2
                    SetNextDestination();
                }
            }
            else
            {
                // Si está persiguiendo al jugador, dirigirse hacia la posición del jugador
                SetDestination(player.position);
            }

            // Verificar si el jugador está lo suficientemente cerca para comenzar a perseguirlo
            if (!isChasing && Vector3.Distance(transform.position, player.position) < chaseDistance)
            {
                isChasing = true;
            }
        }
    }

    void FleeFromPlayer()
    {

    }

    void SetNextDestination()
    {
        // Obtener solo las coordenadas X y Z de la posición actual y de las posiciones de los destinos
        Vector3 currentPos = new Vector3(transform.position.x, 0f, transform.position.z);
        Vector3 direction1Pos = new Vector3(direction1.position.x, 0f, direction1.position.z);
        Vector3 direction2Pos = new Vector3(direction2.position.x, 0f, direction2.position.z);

        // Comparar las coordenadas X y Z para determinar el próximo destino
        if (currentPos == direction1Pos)
        {
            SetDestination(direction2.position);
        }
        else if (currentPos == direction2Pos)
        {
            SetDestination(direction1.position);
        }
    }


    void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
}
