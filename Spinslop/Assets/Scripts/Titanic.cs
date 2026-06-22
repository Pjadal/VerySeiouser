using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titanic : MonoBehaviour
{
    [SerializeField] int hull;
    [SerializeField] PlayerTurn turnHandler;
    public int deckSize;
    public List<Gambler> gamblers;
    public List<Gambler> casino;
    public int block = 0;
    

    private void Start()
    {
        casino = gamblers;
        turnHandler.StartTurn(deckSize);
    }

    public bool Damage(int damage)
    {
        int hullDmg = damage;

        hullDmg -= block;
        if (damage < block)
        {
            block -= damage;
        }
        else
        {
            block = 0;   
        }

        if (hullDmg > 0)
        {
            hull -= hullDmg;
            if (hull <= 0)
            {
                hull = 0;
                return Crash();
            }
        }

        return false;
    }

    public bool Crash()
    {
        Debug.Log("Titanic Titanica dessverre");
        return true;
    }
}
