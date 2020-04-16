using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public GameObject a;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            a.SetActive(false);
        }
    }
}
