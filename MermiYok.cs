using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiYok : MonoBehaviour
{
    
    GameObject Tf;
    ShootingEnemy Em;
    public GameObject carpmaParticle;
    private void Start()
    {
        Tf = GameObject.FindGameObjectWithTag("Teror");
        Em = Tf.GetComponent<ShootingEnemy>();
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
    private void OnTriggerEnter2D(Collider2D other)
    {

        //Çarpişma etkisini kaldırmak için Ontrigger yapısını kullandık
        if (other.gameObject.tag != "Teror")
        {
            Instantiate(carpmaParticle, transform.position, Quaternion.identity);


        }
        else
        {
            Em.EnemyHealth -= 5;

            Instantiate(carpmaParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);  

        }
        if (other.gameObject.tag != "Teror")
        {
            Destroy(gameObject);

        }
    }
}

