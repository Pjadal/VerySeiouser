using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    [SerializeField] PlayerTurn turn;

    private void OnMouseOver()
    {
        if (turn.extended)
        {
            if (Input.GetMouseButtonDown(0)) {
                turn.EndTurn();
            }
        }
    }
}
