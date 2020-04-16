using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    //Fire point için sahnede bir transform belirleniyor
    public Animator anim;
    //Animasyon oluşturuluyor
    
    public GameObject bulletPrefab;
    //Merminin prefebı
    
    public AudioSource AudS;
    public GameObject BulletPar;
    //Merminin particlesi
    public GameObject Kovanprefab;
   
    public int mermiSayisi=30;
    
    
    public Kontrol control;
    public GameObject GameControlOjbe;


    public float bulletForce = 20f;
    public float kovanforce = 5f;
    public float fireRate = 0.01f;
    private float nextTime = 0.0f;
    

    public void Start()
    {
        GameControlOjbe = GameObject.FindGameObjectWithTag("Kontrol");
        //Kontrol nesnesini "GamesControlObje" diye yeni bir boş nesneye aktardık
        control = GameControlOjbe.GetComponent<Kontrol>();
        //"GamesConrolobje" nesnenin bileşeni olan "Kontrol" kodunu "control" diye boş bir koda atararak o kodun özelliklerine ulaşabildik
        
        


    }
    

    
    public void Update()
    {
       
        Destroy(GameObject.Find("Bullet(Clone)"),2f);
        //Clone objeleri destroy ediyoruz.
        Destroy(GameObject.Find("ParticleFire(Clone)"), 2f);

        if (Input.GetButton("Fire1") && Time.time>nextTime && mermiSayisi != 0)
        {
            
            nextTime = Time.time + fireRate;
            Shoot();
            anim.SetBool("Kontrol", true);
            //Burada ates etkisi animasyonu cagırılmakta,varsayılan parametre degeri false olan animasyon true olunca gerçekleşiyor



        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("Kontrol", false);
            //Burada animasyonun döngüde kalmasını engellemek için ateş tuşundan etki çıkınca animasyon durmakta
        }


        else if(Input.GetButtonDown("Fire1") && Time.time > nextTime && mermiSayisi == 0)
        {
            nextTime = Time.time + fireRate;
            control.EmptyGun.Play();
            anim.SetBool("Kontrol", false);

        }

    }

    public void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        AudS.Play();
        Instantiate(BulletPar, firepoint.position, firepoint.rotation);
        
         


        mermiSayisi--;
        if (mermiSayisi <= 0)
        {
            mermiSayisi = 0;
        }
    }
    
}
