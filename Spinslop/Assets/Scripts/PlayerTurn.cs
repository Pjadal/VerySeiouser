using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] Titanic titanic;
    [SerializeField] float extensionSpeed;
    [SerializeField] GameObject deck;
    [SerializeField] GameObject gambler;
    [SerializeField] EndTurnButton endTurn;
    [SerializeField] float initSlotSpeed;
    [SerializeField] float slotSpeedInc;
    public int turnNr = 0;
    public float slotSpeed;
    public bool extended;
    public List<Gambler> availableGamblers = new List<Gambler>();
    private float extension = 4.5f;

    private List<GameObject> deleteList = new List<GameObject>();

    private void Update()
    {
        Transform tf = deck.transform;
        if (extended && tf.localPosition.x < extension - 7.5f)
        {
            tf.localPosition = new Vector3(
                tf.localPosition.x + extensionSpeed * Time.deltaTime, tf.localPosition.y
                );
            if (tf.localPosition.x >= extension - 7.5f)
            {
                endTurn.Activate(turnNr);
            }
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
        turnNr++;
        Debug.Log("Player turn "+ turnNr +": ");

        foreach (GameObject def in deleteList)
        {
            Destroy(def);
        }
        deleteList = new List<GameObject>();

        // resetter deck
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
            deleteList.Add(spawnedGambler);
            Debug.Log("gambler spawned");
        }
    }

    public void SlotStopped()
    {
        slotSpeed += slotSpeedInc;
    }

    public void EndTurn()
    {
        extended = false;
        endTurn.Deactivate();

        // bare inntil enemyturn er laget
        GetComponent<EnemyTurn>().StartTurn();
    }
}
