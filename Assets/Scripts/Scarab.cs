using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    public GameObject[] Pyramid; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < Pyramid.Length - 1; i++)
        {
            if (Pyramid[i].activeSelf)
            {
                Pyramid[i].SetActive(false);
                Pyramid[i + 1].SetActive(true);
                
                break;
            }
        }

        Destroy(gameObject);
    }
}
