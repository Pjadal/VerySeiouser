using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBox : MonoBehaviour
{
    PlayerTurn turn;
    Gambler gambler;
    bool stopped = false;
    Slot finalSlot;
    List<Slot> slots;

    private void Start()
    {
        turn = GameObject.Find("TurnHandler").GetComponent<PlayerTurn>();
        gambler = GetComponentInParent<GamblerHolder>().gambler;
        slots = gambler.startingSlots;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !stopped)
        {
            stopped = true;
            turn.SlotStopped();
            gambler.finalSlot = finalSlot;
        }
    }
}
