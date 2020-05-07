using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioClip StartSound;
    public AudioClip CatSound;
    public AudioClip EndSound;
    private AudioSource MenuSounds;
    private GameObject BlackBackground;
    public void Start()
    {
        BlackBackground = GameObject.Find("BlackBackground");
        BlackBackground.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenuSounds = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        MenuSounds.clip = StartSound;
        MenuSounds.Play();
        BlackBackground.SetActive(true);
    }

    public void StartGame()
    {
        MenuSounds.clip = CatSound;
        MenuSounds.Play();
        StartCoroutine(WaitUntilEndOfStartClip());
    }

    IEnumerator WaitUntilEndOfStartClip()
    {
        yield return new WaitForSeconds(CatSound.length);
        SceneManager.LoadScene("Combined_Mansion_Level");
    }
    public void QuitGame()
    {
        MenuSounds.clip = EndSound;
        MenuSounds.Play();
        StartCoroutine(WaitUntilEndOfEndClip());
    }

    IEnumerator WaitUntilEndOfEndClip()
    {
        yield return new WaitForSeconds(EndSound.length);
        Application.Quit();
    }
}
