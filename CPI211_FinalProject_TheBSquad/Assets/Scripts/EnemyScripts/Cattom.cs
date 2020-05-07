using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cattom : MonoBehaviour
{

    public GameObject player;
    public GameObject projectile;
    public GameObject defProjectile;
    public int health = 6;
    public float maxDistance = 10;
    public float fireRate = 3;
    public float bulletSpeed = 100;

    private NavMeshAgent cattom;
    private float distance;
    private float midDistance;
    private float closeDistance;
    private int midCount = 0;
    private bool tooFar;
    private bool defAttack;
    public bool Aggro = false;

    // Start is called before the first frame update
    void Start()
    {
        cattom = GetComponent<NavMeshAgent>();
        midDistance = maxDistance * (.5f);
        closeDistance = maxDistance * (.1f);
        tooFar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Aggro == true)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);

            if(distance > midDistance)
            {
                cattom.destination = player.transform.position;
                if (distance < maxDistance)
                {
                    StartCoroutine(FarAttack());
                }
            }
            if(distance <= midDistance && distance >= closeDistance)
            {
                cattom.destination = gameObject.transform.localPosition;
                MidAttack();
            }
            if(distance < closeDistance)
            {
                Vector3 dir = transform.position - player.transform.position;
                Vector3 newPos = (transform.position + dir.normalized);
                cattom.destination = newPos;
                defAttack = true;
                StartCoroutine(CloseAttack());
            }
        }
    }

    IEnumerator FarAttack()
    {
        yield return new WaitForSeconds(fireRate);
        tooFar = true;
        ProjectileAttack();
        yield return null;
    }

    IEnumerator CloseAttack()
    {
        yield return new WaitForSeconds(3);
        Defense();
        yield return null;
    }

    private void ProjectileAttack()
    {
        if (tooFar)
        {
            Vector3 position = transform.position + transform.forward;
            GameObject bullet = Instantiate(projectile, position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * bulletSpeed);
                Destroy(bullet, 2f);
            }
            tooFar = false;
        }
    }

    private void MidAttack()
    {
        Vector3 spawnPos = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z);
        Vector3 position = player.transform.position + player.transform.up + player.transform.forward;
        midCount = GameObject.FindGameObjectsWithTag("Projectile").Length;
        if (midCount <= 10)
        {
            GameObject bullet = Instantiate(defProjectile, spawnPos, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            Destroy(bullet, 1f);
        }
    }

    private void Defense()
    {
        if (defAttack)
        {
            Debug.Log("Uh oh");
            Vector3 position = transform.position;
            GameObject attack = Instantiate(defProjectile, position, transform.rotation);

            attack.transform.position = transform.position;
            Destroy(attack, 1f);
        }
        defAttack = false;
    }
}
