using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public AudioClip CatthewHurt;
    public AudioClip Sound2;
    private AudioSource playerSounds;
    private Component ThirdPersonCatControl;

    private void Awake()
    {
        ThirdPersonCatControl = GetComponent<ThirdPersonCatControl>();
        playerSounds = GetComponent<AudioSource>();
        playerSounds.clip = CatthewHurt;
        playerSounds.volume = 0.5f;
        playerSounds.Play();
    }

    private void Update()
    {
        
    }

    private void OnCollisionStay(Collision other)
    {
        // Ends game if  touches player
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionExit(Collision other)
    {

    }

}
