
using UnityEngine;


public class Score : MonoBehaviour
{
	[SerializeField] private GameObject _coinVFX;



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("CanhSat"))
		{
			if (collision.gameObject.transform.position.x < transform.position.x)
			{
				print("Cong diem");
				VfxCoin();
				Destroy(collision.gameObject);

			}
			else if (collision.gameObject.transform.position.x > transform.position.x)
			{
				Destroy(collision.gameObject);
				print("tru diem");
			}
		}

		if (collision.gameObject.CompareTag("PlusPoints"))
		{

			print("Cong diem");
			VfxCoin();
			Destroy(collision.gameObject);


		}


		if (collision.gameObject.CompareTag("MinusPoints"))
		{

			print("Tru diem");
			Destroy(collision.gameObject);

		}



	}

	public void VfxCoin() => _coinVFX.SetActive(true);

}

