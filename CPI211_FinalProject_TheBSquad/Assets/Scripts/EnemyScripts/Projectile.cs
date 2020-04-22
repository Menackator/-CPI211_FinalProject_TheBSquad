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

    private void OnCollisionEnter(Collision collision)
    {
        if (player)
        {
            isHit = true;
            Debug.Log("Shots fired");
            Destroy(this.gameObject);
        }
    }
}
