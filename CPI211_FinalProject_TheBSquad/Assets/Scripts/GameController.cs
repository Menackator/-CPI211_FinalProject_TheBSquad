using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int gameState = 1;
    private GameObject Catthew;
    private GameObject CookCat;

    // Start is called before the first frame update
    void Start()
    {
        Catthew = GameObject.Find("Catthew_SweetCat_s10");
        CookCat = GameObject.Find("CookCat_SweetCat_s17");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == 1)
        {
            Catthew.GetComponent<PlayerStatus>().canBeHurt = false;
        }
        else if (gameState == 2)
        {
            Catthew.GetComponent<PlayerStatus>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = true;
        }
        else if (gameState == 3)
        {
            Catthew.GetComponent<PlayerStatus>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
        }
        else if (gameState == 4)
        {
            
        }
        else if (gameState == 5)
        {
            
        }
        else if (gameState == 6)
        {
            
        }
        else if (gameState == 7)
        {
            
        }
        else if (gameState == 8)
        {
            
        }
        else if (gameState == 9)
        {
            
        }
        else if (gameState == 10)
        {
            
        }
        else if (gameState == 11)
        {
            
        }



    }
}
