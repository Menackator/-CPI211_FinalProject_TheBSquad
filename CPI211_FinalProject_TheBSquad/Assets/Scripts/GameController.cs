using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private AudioSource gameMusic;
    public AudioClip battleTheme1;
    public AudioClip battleTheme2;
    public AudioClip exploreTheme1;
    public AudioClip exploreTheme2;
    public int gameState = 1;
    private GameObject BoolKeeper;
    private GameObject Catthew;
    private GameObject CookCat;
    private GameObject FancyCat;
    private GameObject ButlerCat;
    private GameObject Cattom;
    private int prevGameState;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic = GetComponent<AudioSource>();
        BoolKeeper = GameObject.Find("BoolKeeper");
        Catthew = GameObject.Find("Catthew_SweetCat_s10");
        CookCat = GameObject.Find("CookCat_SweetCat_s17");
        FancyCat = GameObject.Find("FancyCat_SweetCat_s26");
        ButlerCat = GameObject.Find("ButlerCat_SweetCat_s2");
        Cattom = GameObject.Find("Cattom_SweetCat_s15");

        prevGameState = gameState;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameState == 1) // Beginning - Pre CookCat Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = true;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            Catthew.GetComponent<Player>().health = 6;

            if (gameMusic.clip != exploreTheme2)
            {
                gameMusic.clip = exploreTheme2;
                gameMusic.Play();
            }
            
            prevGameState = gameState;
        }
        else if (gameState == 2) // CookCat Fight
        {
            prevGameState = gameState;

            Catthew.GetComponent<Player>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = true;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            if (gameMusic.clip != battleTheme1)
            {
                gameMusic.clip = battleTheme1;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 3) // CookCat Fight Done - Pre FancyCat Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = true;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            Catthew.GetComponent<Player>().health = 6;

            if (gameMusic.clip != exploreTheme2)
            {
                gameMusic.clip = exploreTheme2;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 4) // FancyCat Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = true;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            if (gameMusic.clip != battleTheme1)
            {
                gameMusic.clip = battleTheme1;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 5) // FancyCat Fight Done - DungeonCat Talk
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = true;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            Catthew.GetComponent<Player>().health = 6;

            if (gameMusic.clip != exploreTheme1)
            {
                gameMusic.clip = exploreTheme1;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 6) // ButlerCat Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = true;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            if (gameMusic.clip != battleTheme2)
            {
                gameMusic.clip = battleTheme2;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 7) // ButlerCat Fight Done - Pre Cattom Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = true;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            Catthew.GetComponent<Player>().health = 6;

            if (gameMusic.clip != exploreTheme1)
            {
                gameMusic.clip = exploreTheme1;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 8) // Cattom Fight
        {

            Catthew.GetComponent<Player>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = true;

            if (prevGameState != gameState)
            {
            BoolKeeper.GetComponent<Booleans>().Beginning = false;
            BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
            BoolKeeper.GetComponent<Booleans>().CookFight = false;
            BoolKeeper.GetComponent<Booleans>().FancyHint = false;
            BoolKeeper.GetComponent<Booleans>().FancyFight = false;
            BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
            BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
            BoolKeeper.GetComponent<Booleans>().CattomFight = false;
            }

            if (gameMusic.clip != battleTheme2)
            {
                gameMusic.clip = battleTheme2;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
        else if (gameState == 9) // Cattom Fight Done - End
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
            FancyCat.GetComponent<FancyCat>().Aggro = false;
            ButlerCat.GetComponent<ButlerCat>().Aggro = false;
            Cattom.GetComponent<Cattom>().Aggro = false;

            if (prevGameState != gameState)
            {
                BoolKeeper.GetComponent<Booleans>().Beginning = false;
                BoolKeeper.GetComponent<Booleans>().PoisonHint = false;
                BoolKeeper.GetComponent<Booleans>().CookFight = false;
                BoolKeeper.GetComponent<Booleans>().FancyHint = false;
                BoolKeeper.GetComponent<Booleans>().FancyFight = false;
                BoolKeeper.GetComponent<Booleans>().DungeonFight = false;
                BoolKeeper.GetComponent<Booleans>().ButlerFight = false;
                BoolKeeper.GetComponent<Booleans>().CattomFight = true;
            }

            Catthew.GetComponent<Player>().health = 6;

            if (gameMusic.clip != exploreTheme1)
            {
                gameMusic.clip = exploreTheme1;
                gameMusic.Play();
            }

            prevGameState = gameState;
        }
    }
}
