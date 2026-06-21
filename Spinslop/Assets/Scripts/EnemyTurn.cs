using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] Titanic titanic;
    [SerializeField] float turnDur;

    public void StartTurn()
    {
        StartCoroutine(EnemyDo());
    }

    public IEnumerator EnemyDo(EnemyMove move = null)
    {
        yield return new WaitForSeconds(turnDur/2);
        
        Debug.Log("Enemy turn: does " + move);
        if (move != null)
        {
            foreach (MoveStats actions in move.move)
            {

            }
        } else { Debug.Log("Heeheeheehaw"); }
     
        yield return new WaitForSeconds(turnDur/2);

        GetComponent<PlayerTurn>().StartTurn(titanic.deckSize);
    }
}
