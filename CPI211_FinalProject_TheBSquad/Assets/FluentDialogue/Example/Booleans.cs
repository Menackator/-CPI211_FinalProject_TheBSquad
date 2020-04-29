using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fluent;

public class Booleans : MonoBehaviour
{
    public bool Beginning;
    public bool PoisonHint;
    public bool CookFight;
    public bool FancyHint;
    public bool FancyFight;
    public bool DungeonFight;
    public bool ButlerFight;
    public bool CattomFight;

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
