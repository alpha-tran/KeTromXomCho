using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTag : MonoBehaviour
{
	public string[] tagsToAssign;
	public GameObject obj;
	void Start()
	{


		GameObject obj = GameObject.Find("YourGameObjectName");

		if (obj != null)
		{
			// Gắn các tag cho GameObject
			string[] tags = { "Tag1", "Tag2", "Tag3" };
			obj.tag = string.Join(",", tags); 
		}


	}
}
