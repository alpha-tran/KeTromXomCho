using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTag : MonoBehaviour
{
	public string[] tagsToAssign;

	void Start()
	{
		foreach (string tagToAssign in tagsToAssign)
		{
			GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagToAssign);
			foreach (GameObject obj in gameObjects)
			{
				obj.tag = tagToAssign;
			}
		}
	}
}
