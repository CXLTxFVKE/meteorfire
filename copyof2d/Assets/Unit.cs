using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[System.Serializable]
public class Unit : MonoBehaviour {
	string unitName;
	[SerializeField]
	protected bool isMoveable,isIdle;
	protected bool isVulnerable;
	protected bool isFriendly, isPickup;
	[SerializeField]
	[Range(-5,50)]
	protected int movespeed, maxspeed, health;

	//CUSTOM EDITOR
	[CustomEditor(typeof(Unit),true)]
	public class UnitEditor : Editor 
	{
		public override void OnInspectorGUI()
		{
			Unit myUnit = target as Unit;

			myUnit.isMoveable = EditorGUILayout.Toggle ("isMoveable" , myUnit.isMoveable);
			if (myUnit.isMoveable)
			{
				myUnit.movespeed = EditorGUILayout.IntSlider("Acceleration Rate",myUnit.movespeed,-10,40);
				myUnit.maxspeed = EditorGUILayout.IntSlider("Top Speed",myUnit.maxspeed,-10,40);
			}

			if (myUnit == GameObject.FindWithTag("Enemy"))
			{
				myUnit.isIdle = EditorGUILayout.Toggle ("isMoveable" , myUnit.isIdle);
			}
				myUnit.isMoveable = EditorGUILayout.Toggle ("isMoveable" , myUnit.isMoveable);
				
			if (GUI.changed) 
			{
				EditorUtility.SetDirty (target);
			}
		}
	}
}
