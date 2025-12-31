using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Codice.Client.Common.EventTracking.TrackFeatureUseEvent.Features.DesktopGUI.Filters;

public class Zombie : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public NavMeshAgent agent;

    public Animator anim;

    public Player player;

    public float attackRange;
    
    public int power = 5;

    public bool playerInRange;

    [Range(0,100)]
    public int health = 100;

    private void Start()
    {
        player = GameManager.instance.player;
    }

    public void Update()
    {
        if (!player) return;
        if (player)
        {
            agent.SetDestination(player.transform.position);
        }

        playerInRange = Vector3.Distance(player.transform.position, transform.position) <= attackRange;

        if (health < 0)
        {
            anim.SetTrigger("death");
            StartCoroutine(Dead());
        }
    
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        player.kills++;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            StartCoroutine(Kill());
        }
    }

    IEnumerator Kill()
    {
        while (playerInRange && player.health > 0)
        {
            player.health -= power;
            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
