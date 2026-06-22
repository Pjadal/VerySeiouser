using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamblerHolder : MonoBehaviour
{
    public Gambler gambler;

    public void SetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = gambler.sprite;
    }


}
