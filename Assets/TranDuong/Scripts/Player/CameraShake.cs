using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake(Camera mainCamera,float duration, float magnitude)
	{
		Vector3 originalPos = mainCamera.transform.localPosition;
		float elapse = 0f;
		while (elapse < duration)
		{
		
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			mainCamera.transform.localPosition = new Vector3(x, y, originalPos.z);

			elapse += Time.deltaTime;
			yield return null;
		}

		mainCamera.transform.localPosition = originalPos;
	}
}
