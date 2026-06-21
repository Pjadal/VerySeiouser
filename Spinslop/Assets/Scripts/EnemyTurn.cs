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
            foreach (MoveStats action in move.move)
            {
                switch (action.type[0])
                {
                    case MoveType.ATTACK:
                        titanic.Damage(action.moveStrength[0]);
                        break;
                    case MoveType.BUFF:
                        break;
                    case MoveType.DEBUFF:
                        break;
                    case MoveType.DEFEND:
                        break;
                }
            }
        } else { Debug.Log("Heeheeheehaw"); }
     
        yield return new WaitForSeconds(turnDur/2);

        GetComponent<PlayerTurn>().StartTurn(titanic.deckSize);
    }
}
