using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Reload : MonoBehaviour
{
    public GameObject mermiKutusuShooting;
    public Shooting mermiFulle;
    public GameObject mermiKutusu;
    public AudioSource reloadvoice;
    public SpriteRenderer mermisprte;
    

    void Start()
    {
        mermiKutusuShooting = GameObject.FindGameObjectWithTag("RifleSoldier");
        mermiFulle = mermiKutusuShooting.GetComponent<Shooting>();
    }
    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "RifleSoldier")
    //    {
    //        mermiFulle.mermiSayisi = 30;
    //        mermisprte.enabled = false;
    //        mermicollider.enabled = false;
    //        reloadvoice.Play();
    //        Destroy(gameObject, 2f);
    //    }

    //}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "RifleSoldier")
        {
            mermiFulle.mermiSayisi = 30;
            mermisprte.enabled = false;
            
            reloadvoice.Play();
            Destroy(gameObject, 2f);
        }
    }
}
