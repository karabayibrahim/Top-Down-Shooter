using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMermiYok : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    public  GameObject Rf;
    public  PlayerMovement_ pm;
    public float max=100;
    public  GameObject HealthS;
    public  HealthSystem Hs;
    
    
    public GameObject carpmaParticle;
    private void Start()
    {
        Rf = GameObject.FindGameObjectWithTag("RifleSoldier");
        pm = Rf.GetComponent<PlayerMovement_>();
        HealthS = GameObject.Find("HealthSystem");
        Hs = HealthS.GetComponent<HealthSystem>();
        
    }
    
    //private void OnCollisionEnter2D(Collision2D other)
    //{

    //    if (other.gameObject.tag != "Teror")
    //    {
    //        Instantiate(carpmaParticle, transform.position, Quaternion.identity);


    //    }
    //    if (other.gameObject.tag != "Teror")
    //    {
    //        Destroy(gameObject);

    //    }

    //}
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RifleSoldier")
        {
            Hs.Playertakedamage(Hs.PlayerHealth);

            Hs.PlayerHealth = Hs.Playertakedamage(Hs.PlayerHealth);



            Instantiate(carpmaParticle, transform.position, Quaternion.identity);
            
            

        }
        //Çarpişma etkisini kaldırmak için Ontrigger yapısını kullandık
        if (other.gameObject.tag != "Teror")
        {
            if (other.gameObject.tag == "Med")
            {

            }
            else
            {
                Instantiate(carpmaParticle, transform.position, Quaternion.identity);
            }
            


        }
        if (other.gameObject.tag != "Teror")
        {
            if (other.gameObject.tag == "Med")
            {

            }
            else
            {
                Destroy(gameObject);
            }
            

        }
        
    }
}

