using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class Booleans : MonoBehaviour
{
    public bool Beginning;      // GameState = 1
    public bool PoisonHint;     // GameState = 1
    public bool CookFight;      // GameState = 3
    public bool FancyHint;      // GameState = 3
    public bool FancyFight;     // GameState = 5
    public bool DungeonFight;   // GameState = 5
    public bool ButlerFight;    // GameState = 7
    public bool CattomFight;    // GameState = 9

    void Start()
    {
        Beginning = true;
        PoisonHint = false;
        CookFight = false;
        FancyHint = false;
        FancyFight = false;
        DungeonFight = false;
        ButlerFight = false;
        CattomFight = false;
    }
}
