using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject player;

    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            isHit = true;
            Debug.Log("Shots fired");
            Destroy(this.gameObject);
        }
    }
}

