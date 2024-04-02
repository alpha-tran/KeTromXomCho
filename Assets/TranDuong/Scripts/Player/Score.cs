using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CanhSat"))
        {
            if (collision.gameObject.transform.position.x < transform.position.x)
            {
                print("Cong diem");

            }
            else if (collision.gameObject.transform.position.x > transform.position.x )
            {
                print("tru diem");
            }
        }


        if (collision.gameObject.CompareTag("PlusPoints"))
        {        
                print("Cong diem");   
        }


        if (collision.gameObject.CompareTag("MinusPoints"))
        {
                print("Tru diem");
        }
    }

}

