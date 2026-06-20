using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titanic : MonoBehaviour
{
    [SerializeField] int hull;
    public int deckSize;
    public List<Gambler> casino;
    public List<Gambler> gamblers;

    private void Start()
    {
        gamblers = casino;
    }
}
