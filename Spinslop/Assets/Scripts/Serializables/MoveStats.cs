using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType { ATTACK, DEFEND, BUFF, DEBUFF };
[System.Serializable]
public class MoveStats
{
	public MoveType[] type;
	public int[] moveStrength;
}
