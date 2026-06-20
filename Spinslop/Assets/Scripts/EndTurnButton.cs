using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponentInParent<PlayerTurn>().EndTurn();
        }
    }
}
