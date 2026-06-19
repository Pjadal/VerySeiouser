using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType { ATTACK, DEFENSE, OTHER};

[System.Serializable]
public class Slot
{
	public SlotType type;
	public int slotStrength;
}
