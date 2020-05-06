using System.Collections;
using System.Collections.Generic;
using Fluent;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioClip CatthewHurt;
    
    
    private AudioSource playerSounds;
    private Component ThirdPersonCatControl;
    public static Player Instance;
    private GameObject Catthew_Health;
    public bool canBeHurt;
    public int health = 6;
    private int prevHealth;
    public float damageDelay = 2f;
    private IEnumerator damageDelayRoutine;
    private bool[] healthPaws = new bool[6];

    void Awake()//removed private
    {
        Instance = this;

        // Health setup
        prevHealth = health;

        for (int i = 0; i < healthPaws.Length; i += 1)
        {
            healthPaws[i] = true;
        }

        // UI Elements
        Catthew_Health = GameObject.Find("Catthew_Health");
        
        // Sound Elements
        ThirdPersonCatControl = GetComponent<ThirdPersonCatControl>();
        playerSounds = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Fluent Manager Update
        if (Input.GetKeyDown(KeyCode.E) && canBeHurt == false)
        {
            FluentManager.Instance.ExecuteClosestAction(gameObject);
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
                Catthew_Health.transform.GetChild(i).gameObject.active = healthPaws[i];
                counter++;
            }
            prevHealth = health;
        }
        

    }

    private void OnCollisionStay(Collision other)
    {
        // Ends game if  touches player
        if(other.gameObject.CompareTag("Enemy") && damageDelayRoutine == null && canBeHurt == true)
        {
            health--;

            playerSounds.clip = CatthewHurt;
            playerSounds.volume = 0.5f;
            playerSounds.Play();

            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            damageDelayRoutine = DamageDelay();
            StartCoroutine(damageDelayRoutine);
        }
    }

    private void OnCollisionExit(Collision other)
    {

    }

    private IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(damageDelay);

        damageDelayRoutine = null;

        yield return null;
    }

}
