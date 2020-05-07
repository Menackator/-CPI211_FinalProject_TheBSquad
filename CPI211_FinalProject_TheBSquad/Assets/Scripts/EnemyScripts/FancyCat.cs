using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FancyCat : MonoBehaviour
{
    private int prevHealth;
    private bool[] healthPaws = new bool[4];
    private AudioSource playerSounds;
    private Vector3 idlePosition;
    private Quaternion idleRotation;
    private GameObject Cat_Health;
    public AudioClip Cat_Hurt;
    public float damageDelay = 2f;
    private IEnumerator damageDelayRoutine;
    public GameObject player;
    public GameObject projectile;
    public int health = 4;
    
    public float attackDis = 5;
    public bool Aggro = false;

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

        // Health setup
        prevHealth = health;

        for (int i = 0; i < healthPaws.Length; i += 1)
        {
            healthPaws[i] = true;
        }
        playerSounds = GetComponent<AudioSource>();

        idlePosition = gameObject.transform.position;
        idleRotation = gameObject.transform.rotation;

        // UI Elements
        Cat_Health = GameObject.Find("FancyCat_Health");
        Cat_Health.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Aggro == true)
        {
            if (Cat_Health.activeInHierarchy == false)
            {
                Cat_Health.SetActive(true);
            }

            // Updates the health paws in the UI
            if (health != prevHealth)
            {
                int counter = 0;
                for (int i = 0; i < healthPaws.Length; i += 1)
                {
                    if (counter < health)
                    {
                        healthPaws[i] = true;
                    }
                    else 
                    {
                        healthPaws[i] = false;
                    }
                    Cat_Health.transform.GetChild(i).gameObject.active = healthPaws[i];
                    counter++;
                }
                prevHealth = health;
            }

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
        else
        {
            gameObject.transform.position = idlePosition;
            gameObject.transform.rotation = idleRotation;

            if (Cat_Health.activeInHierarchy == true)
            {
                Cat_Health.SetActive(false);
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

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<ThirdPersonCatControl>().AttackState == true && Aggro == true && damageDelayRoutine == null)
        {
            health--;

            playerSounds.clip = Cat_Hurt;
            playerSounds.Play();

            if (health <= 0)
            {
                Cat_Health.SetActive(false);
                GameObject.Find("GameController").GetComponent<GameController>().gameState = 5;
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
