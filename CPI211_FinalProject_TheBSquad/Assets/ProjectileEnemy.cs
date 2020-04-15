using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileEnemy : MonoBehaviour
{
    public Transform player;
    public GameObject projectile;
    public float fireRate = 3;
    public float bulletSpeed = 3; 
    public float maxDistance = 10;

    private NavMeshAgent enemy;
    private Vector3 originalPosition;
    private float distance;
    private bool isHit;
    private float far;
    private float close;
    private float originalFireRate;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalPosition = gameObject.transform.localPosition;
        isHit = false;
        far = (float)(maxDistance * (2.0 / 3.0));
        close = (float)(maxDistance * (1.0 / 3.0));
        originalFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates distance between player and the enemy. 
        distance = Vector3.Distance(player.position, enemy.transform.position);
        //fireRate -= Time.deltaTime;

        if (player != null && distance <= maxDistance)
        {
            transform.LookAt(player);
        }

        //if enemy is within distance of player, follow him. If not, stay put. 
        if (distance < maxDistance)
        {
            fireRate -= Time.deltaTime;

            if ((distance > far))       //too far away
            {
                enemy.destination = player.position;
            }
            if((distance <= far) && (distance >= close))    //perfect distance
            {
                enemy.destination = gameObject.transform.localPosition;
            }
            if ((distance < close))     //too close
            {
                Vector3 dir = transform.position - player.position;
                Vector3 newPos = (transform.position + dir.normalized);
                enemy.destination = newPos;
            }

            //throw projectile
            if (fireRate <= 0)
            {
                Vector3 position = transform.position + transform.forward;
                GameObject bullet = Instantiate(projectile, position, transform.rotation);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Debug.Log("FIRE!");
                    rb.AddForce(transform.forward * bulletSpeed);
                    Destroy(bullet, 3f);
                }
                fireRate = originalFireRate;
            }

        }
        else
        {
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
