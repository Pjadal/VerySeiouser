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
    [SerializeField] GameObject gambler;
    [SerializeField] GameObject killBox;
    [SerializeField] float initSlotSpeed;
    [SerializeField] float slotSpeedInc;
    public float slotSpeed;
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
        killBox.SetActive(false);
        slotSpeed = initSlotSpeed;
        availableGamblers = new List<Gambler>();

        // resetter casino (bare en idé å resette hver turn, kan gjøre full shuffle, men virker interessant)
        Gambler[] newCasino = new Gambler[titanic.gamblers.Count];
        titanic.gamblers.CopyTo(newCasino);
        titanic.casino = newCasino.ToList();

        // fyller decket
        for (int i = 0; i < deckSize; i++)
        {
            Draw(i);
        }
        extended = true;
        extension = deckSize * 1.5f;

        // fjerner block
        titanic.block = 0;
    }

    public void Draw(int space)
    {
        if (titanic.casino.Count > 0) {
            int gamblerIndex = Random.Range(0, titanic.casino.Count);
            availableGamblers.Add(titanic.casino[gamblerIndex]);
            titanic.casino.RemoveAt(gamblerIndex);
            GameObject spawnedGambler = Instantiate(gambler, deck.transform.GetChild(0).GetChild(space));
            spawnedGambler.GetComponent<GamblerHolder>().gambler = availableGamblers[space];
            spawnedGambler.GetComponent<GamblerHolder>().SetSprite();
        }
    }

    public void SlotStopped()
    {
        slotSpeed += slotSpeedInc;
    }

    public void EndTurn()
    {
        extended = false;
        killBox.SetActive(true);

        // bare inntil enemyturn er laget
        GetComponent<EnemyTurn>().StartTurn();
    }
}
