using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FancyCat : MonoBehaviour
{

    public GameObject player;
    public GameObject rush;         //rush enemy
    public GameObject projectile;   //projectile enemy
    public int health = 8;
    public int maxSpawnRush = 3;
    public int maxSpawnProjectile = 3;
    public int spawnDelay = 3;

    private NavMeshAgent oliver;    //fancy cat name
    private Vector3 originalPosition;
    private int rushCount = 0;
    private int projectileCount = 0;
    private bool enemySpawned;

    // Start is called before the first frame update
    void Start()
    {
        oliver = GetComponent<NavMeshAgent>();
        originalPosition = transform.localPosition;

        enemySpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
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
}
