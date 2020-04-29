using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FancyCat : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public int health = 6;
    public float attackDis = 5;
    public bool canFight = true;

    private NavMeshAgent benny;
    private float distance;
    private bool canMove;
    private float closeAttack;
    private int dungPro = 0;

    // Start is called before the first frame update
    void Start()
    {
        benny = GetComponent<NavMeshAgent>();
        canMove = true;
        closeAttack = attackDis *(.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canFight)
        {
            //calculates distance between player and the enemy. 
            distance = Vector3.Distance(player.transform.position, benny.transform.position);

            if (canMove)
            {
                benny.destination = player.transform.position;
            }

            if(distance <= attackDis && distance > closeAttack)
            {
                canMove = true;
                ProjectileAttack();
            }
        }
    }

    void ProjectileAttack()
    {
        Vector3 spawnPos = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
        Vector3 position = player.transform.position + player.transform.up + player.transform.forward;
        dungPro = GameObject.FindGameObjectsWithTag("Dungeon Projectile").Length;
        if (dungPro <= 20)
        {
            GameObject bullet = Instantiate(projectile, spawnPos, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(0, -100, 0);
            }
            Destroy(bullet, 3f);
        }
    }
}
