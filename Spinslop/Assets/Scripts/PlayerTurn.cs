using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] Titanic titanic;
    [SerializeField] bool extended;
    public List<Gambler> availableGamblers = new List<Gambler>();
    
    public void StartTurn(int deckSize)
    {
        // resetter deck
        availableGamblers = new List<Gambler>();

        // resetter casino (bare en idé å resette hver turn, kan gjøre full shuffle, men virker interessant)
        Gambler[] newOrder = new Gambler[titanic.gamblers.Count];
        titanic.gamblers.CopyTo(newOrder);
        titanic.casino = newOrder.ToList();

        // fyller decket
        for (int i = 0; i < deckSize; i++)
        {
            Draw();
        }
        extended = true;
    }

    public void Draw()
    {
        if (titanic.casino.Count > 0) {
            int gamblerIndex = Random.Range(0, titanic.casino.Count);
            availableGamblers.Add(titanic.casino[gamblerIndex]);
            titanic.casino.RemoveAt(gamblerIndex);
        }
    }

    public void EndTurn()
    {
        extended = false;

        // bare inntil enemyturn er laget
        StartTurn(titanic.deckSize);
    }
}
