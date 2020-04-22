using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject field;
    public int health = 3;
    public float maxDistance = 10;
    public float howClose = 2;

    private NavMeshAgent enemy;
    private Vector3 originalPosition;
    private float distance;
    private float attackRange;
    private bool isHit;
    private bool isClose;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        originalPosition = transform.localPosition;
        isHit = false;
        isClose = false;
        attackRange = maxDistance * (howClose/10f);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, enemy.transform.position);

        //within the range
        if(distance < maxDistance)
        {
            if (player != null)
            {
                transform.LookAt(player.transform);
            }

            if(distance > attackRange)
            {
                enemy.destination = player.transform.position;
            }
            else if(distance <= attackRange && !isClose)
            {
                isClose = true;
                enemy.destination = transform.localPosition;
                StartCoroutine(Cooldown(1));
            }
        }
        else
        {
            enemy.destination = originalPosition;
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        Attack();
        yield return null;
    }

    void Attack()
    {
        if (isClose)
        {
            Vector3 position = transform.position;
            GameObject attack = Instantiate(field, position, transform.rotation);
           
            attack.transform.position = transform.position;
            Destroy(attack, 1f);
        }
        isClose = false;
    }
}
