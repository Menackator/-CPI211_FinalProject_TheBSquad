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
        if (gameState == 1) // Beginning
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
        }
        else if (gameState == 2) // Poison Hint
        {
            Catthew.GetComponent<Player>().canBeHurt = true;
            CookCat.GetComponent<CookCat>().Aggro = true;
        }
        else if (gameState == 3) // Cook Fight
        {
            Catthew.GetComponent<Player>().canBeHurt = false;
            CookCat.GetComponent<CookCat>().Aggro = false;
        }
        else if (gameState == 4) // Fancy Hint
        {
            
        }
        else if (gameState == 5) // Fancy Fight
        {
            
        }
        else if (gameState == 6) // Dungeon Fight
        {
            
        }
        else if (gameState == 7) // Butler Fight
        {
            
        }
        else if (gameState == 8) // Cattom Fight
        {
            
        }
        else if (gameState == 9) // End
        {

        }
    }
}
