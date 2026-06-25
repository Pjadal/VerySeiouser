using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    [SerializeField] PlayerTurn turn;
    [SerializeField] Color colDeactive;
    [SerializeField] Color colActive;
    private bool interactable = false;

    private void OnMouseOver()
    {
        if (turn.extended && interactable)
        {
            if (Input.GetMouseButtonDown(0)) {
                turn.EndTurn();
            }
        }
    }

    public void Deactivate()
    {
        GetComponent<SpriteRenderer>().color = colDeactive;
        interactable = false;
    }

    public void Activate(int turnNr)
    {
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "End turn " + turnNr;
        GetComponent<SpriteRenderer>().color = colActive;
        interactable = true;
    }
}
