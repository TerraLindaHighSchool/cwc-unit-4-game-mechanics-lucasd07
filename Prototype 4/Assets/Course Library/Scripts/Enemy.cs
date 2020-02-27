using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody enemyRb;
    private GameObject player;

    private Vector3 lookDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(lookDirection * speed);
        lookDirection = (player.transform.position - transform.position).normalized;
    }
}
