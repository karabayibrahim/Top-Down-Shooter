using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public float HealthGive = 25;
    GameObject HealthS;
    HealthSystem Hs;

    private void Start()
    {
        HealthS = GameObject.Find("HealthSystem");
        Hs = HealthS.GetComponent<HealthSystem>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="RifleSoldier")
        {
            
            Hs.PlayerGainHealth(Hs.PlayerHealth);
            Hs.PlayerHealth = Hs.PlayerGainHealth(Hs.PlayerHealth);
            Destroy(gameObject);
           
        }
    }
}
