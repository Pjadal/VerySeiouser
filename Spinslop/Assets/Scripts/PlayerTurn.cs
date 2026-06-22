using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] Titanic titanic;
    [SerializeField] float extensionSpeed;
    [SerializeField] GameObject deck;
    public bool extended;
    public List<Gambler> availableGamblers = new List<Gambler>();
    private float extension = 4.5f;

    private void Update()
    {
        Transform tf = deck.transform;
        if (extended && tf.localPosition.x < extension - 7.5f)
        {
            tf.localPosition = new Vector3(
                tf.localPosition.x + extensionSpeed * Time.deltaTime, tf.localPosition.y
                );
        }
        else if (!extended && tf.localPosition.x > -7.5f)
        {
            tf.localPosition = new Vector3(
                tf.localPosition.x - extensionSpeed * Time.deltaTime, tf.localPosition.y
                );
        }
    }

    public void StartTurn(int deckSize)
    {
        Debug.Log("Player turn: ");

        // resetter deck
        availableGamblers = new List<Gambler>();

        // resetter casino (bare en idé å resette hver turn, kan gjøre full shuffle, men virker interessant)
        Gambler[] newCasino = new Gambler[titanic.gamblers.Count];
        titanic.gamblers.CopyTo(newCasino);
        titanic.casino = newCasino.ToList();

        // fyller decket
        for (int i = 0; i < deckSize; i++)
        {
            Draw();
        }
        extended = true;
        extension = deckSize * 1.5f;

        // fjerner block
        titanic.block = 0;
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
        GetComponent<EnemyTurn>().StartTurn();
    }
}
