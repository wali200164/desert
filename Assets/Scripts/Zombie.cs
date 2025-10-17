using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    public Transform player;        // Reference to the player
    public float chaseRange = 30f;  // How far the zombie can detect the player
    public float speed = 3.5f;      // Zombie speed (adjust in Inspector)

    public int health = 3;

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed; // Set speed at start

        // If player not assigned manually, find it by tag
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            agent.speed = speed; // Update speed (in case changed during runtime)
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath(); // Stop moving if too far
        }
    }

    public void damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
