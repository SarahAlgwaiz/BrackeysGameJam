using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;

    Vector3 moveDirection;

    Player player;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
        
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rigidBody.velocity = moveDirection;
    }
}
