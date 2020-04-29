using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileEnemy : MonoBehaviour
{
    public int health = 3;
    public float damageDelay = 2f;
    private IEnumerator damageDelayRoutine;

    public GameObject player;
    public GameObject projectile;
    public bool Aggro = false;
    
    public float fireRate = 3;
    public float bulletSpeed = 500; 
    public float maxDistance = 10;

    private NavMeshAgent enemy;
    private Vector3 originalPosition;
    private float distance;
    
    private float far;
    private float close;
    private float originalFireRate;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalPosition = gameObject.transform.localPosition;
        far = (float)(maxDistance * (2.0 / 3.0));
        close = (float)(maxDistance * (1.0 / 3.0));
        originalFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Aggro == true)
        {
            //calculates distance between player and the enemy. 
            distance = Vector3.Distance(player.transform.position, enemy.transform.position);

            if (player != null && distance <= maxDistance)
            {
                transform.LookAt(player.transform);
            }

            //if enemy is within distance of player, follow him. If not, stay put. 
            if (distance < maxDistance)
            {
                fireRate -= Time.deltaTime;

                if ((distance > far))       //too far away
                {
                    enemy.destination = player.transform.position;
                }
                if((distance <= far) && (distance >= close))    //perfect distance
                {
                    enemy.destination = gameObject.transform.localPosition;
                }
                if ((distance < close))     //too close
                {
                    Vector3 dir = transform.position - player.transform.position;
                    Vector3 newPos = (transform.position + dir.normalized);
                    enemy.destination = newPos;
                }

                //throw projectile
                if (fireRate <= 0)
                {
                    Vector3 position = transform.position + transform.forward/2;
                    GameObject bullet = Instantiate(projectile, position, transform.rotation);
                    Rigidbody rb = bullet.GetComponent<Rigidbody>();
                    if (rb != null || rb == null)
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

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<ThirdPersonCatControl>().AttackState == true && Aggro == true && damageDelayRoutine == null)
        {
            health--;

            if (health <= 0)
            {
                Destroy(this.gameObject);
            }

            damageDelayRoutine = DamageDelay();
            StartCoroutine(damageDelayRoutine);
            
        }
    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);

        damageDelayRoutine = null;

        yield return null;
    }

}
