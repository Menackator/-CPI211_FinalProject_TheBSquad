using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RushEnemy : MonoBehaviour
{

    public Transform player;
    public float maxDistance = 10;

    private NavMeshAgent enemy;
    private Vector3 originalPosition;
    private float distance;
    private bool isHit; 

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalPosition = gameObject.transform.localPosition;
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates distance between player and the enemy. 
        distance = Vector3.Distance(player.position, enemy.transform.position);
        
        //if enemy is within distance of player, follow him. If not, stay put. 
        if (distance < maxDistance)
        {
            enemy.destination = player.position;

            if(player != null)
            {
                transform.LookAt(player);
            }

        }
        else {
            enemy.destination = originalPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (player)
        {
            isHit = true;
            Debug.Log("gotcha bitch");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (player)
        {
            isHit = false;
            Debug.Log("You safe");
        }
    }
}
