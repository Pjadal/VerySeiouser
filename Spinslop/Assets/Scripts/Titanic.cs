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
    

    private void Start()
    {
        casino = gamblers;
        turnHandler.StartTurn(deckSize);
    }
}
