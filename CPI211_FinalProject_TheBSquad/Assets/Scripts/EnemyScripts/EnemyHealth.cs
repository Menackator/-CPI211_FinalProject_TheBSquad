using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyHealth : MonoBehaviour
{

    public int health = 3;
    public float damageDelay = 2f;
    private IEnumerator damageDelayRoutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<ThirdPersonCatControl>().AttackState == true && damageDelayRoutine == null)
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