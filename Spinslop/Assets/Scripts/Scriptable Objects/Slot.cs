using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotType { ATTACK, DEFENSE, OTHER};

[CreateAssetMenu(menuName = "Slot")]
public class Slot : ScriptableObject
{
	public SlotType type;
}
