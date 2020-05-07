using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ButlerCat : MonoBehaviour
{
    private int prevHealth;
    private bool[] healthPaws = new bool[5];
    private AudioSource playerSounds;
    private Vector3 idlePosition;
    private Quaternion idleRotation;
    private GameObject Cat_Health;
    public AudioClip Cat_Hurt;
    public float damageDelay = 2f;
    private IEnumerator damageDelayRoutine;
    public GameObject player;
    public GameObject rush;         //rush enemy
    public GameObject projectile;   //projectile enemy
    public int health = 5;
    public int maxSpawnRush = 3;
    public int maxSpawnProjectile = 3;
    public int spawnDelay = 3;

    private NavMeshAgent oliver;    //fancy cat name
    private Vector3 originalPosition;
    private int rushCount = 0;
    private int projectileCount = 0;
    private bool enemySpawned;
    public bool Aggro = false;

    // Start is called before the first frame update
    void Start()
    {
        oliver = GetComponent<NavMeshAgent>();
        originalPosition = transform.localPosition;

        enemySpawned = false;

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
        Cat_Health = GameObject.Find("ButlerCat_Health");
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

            Vector3 dir = transform.position - player.transform.position;
            Vector3 newPos = (transform.position + dir.normalized);
            oliver.destination = newPos;

            rushCount = GameObject.FindGameObjectsWithTag("Rush").Length;               //number of rush enemies present
            projectileCount = GameObject.FindGameObjectsWithTag("Projectile").Length;   //number of projectile enemies present

            if (rushCount < maxSpawnRush && !enemySpawned)
            {
                StartCoroutine(SpawnWait(rush));
            }
            if (projectileCount < maxSpawnProjectile && !enemySpawned)
            {
                StartCoroutine(SpawnWait(projectile));
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

    private void SpawnEnemy(GameObject enemyType)
    {
        Vector3 position = transform.position - transform.forward;
        GameObject enemy = Instantiate(enemyType, position, transform.rotation);
        enemySpawned = false;
    }

    IEnumerator SpawnWait(GameObject enemyType)
    {
        enemySpawned = true;
        yield return new WaitForSeconds(spawnDelay);
        SpawnEnemy(enemyType);
        yield return null;
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
                GameObject.Find("GameController").GetComponent<GameController>().gameState = 7;
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
