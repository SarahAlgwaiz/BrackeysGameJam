using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericAI : MonoBehaviour
{
    [SerializeField]
    bool isRanged = false;

    [SerializeField]
    float health = 100;

    [SerializeField]
    float speed = 2.5f;

    [SerializeField]
    float detectionDistance = 30f;

    [SerializeField]
    float attackRange = 2f;

    [SerializeField]
    float attackDelay = 0.5f;

    [SerializeField]
    GameObject enemyProjectile;
    
    [SerializeField]
    GameObject projectilePoint;

    float distanceFromPlayer;

    float nextAttack = 0;

    float fleeHealth;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        fleeHealth = health * 0.25f;

        if (isRanged)
            attackRange = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && health > fleeHealth)
        {
            PlayerDetectionAndAttack();
        }

        if (health <= fleeHealth && distanceFromPlayer < attackRange)
        {
            FleeFromPlayer();
        }
    }

    private void FleeFromPlayer()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos * -1, Vector3.up);
        transform.rotation = rotation;
        
        if (distanceFromPlayer < 50f)
            transform.position += Vector3.forward * Time.deltaTime * speed;
    }

    private void PlayerDetectionAndAttack()
    {
        Vector3 relativePos = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
        
        if (distanceFromPlayer < detectionDistance)
        {
            transform.rotation = rotation;
            
            if (distanceFromPlayer > attackRange)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }
            else
            {
                if (Time.time > nextAttack)
                {
                    if (isRanged)
                        Instantiate(enemyProjectile, projectilePoint.transform.position, Quaternion.identity);
                    else
                        Debug.Log("Melee Attacking");
                    nextAttack = Time.time + attackDelay;
                }
            }
        }
    }
}
