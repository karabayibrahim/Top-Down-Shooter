using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    
    Shooting Sh;
    PlayerMovement_ pm;
    GameObject code;
    GameObject moveCode;
    GameObject Enemy;
    ShootingEnemy Se;
    public float normalTime = 1.0f;
    public float slowMo = 0.1f;
    public bool slowMoKontrol = false;
    float max = 100;

    public GameObject rifle_sol;
    //Silahlı askerin oyun objesi
    public GameObject knife_sol_render;
    public GameObject rifle_sol_render;
    public GameObject knife_pc_ob;
    //Bıçaklı askerin rendererının oyun objesi
    //public SpriteRenderer knife_sol_sr;
    public AudioSource EmptyGun;
    public PolygonCollider2D knife_pc;
    //Bıçaklı askerin sprite rendererı



    void Start()
    {
        
        code = GameObject.FindGameObjectWithTag("RifleSoldier");
        //RifleSoldier etiketli oyun objesini kod ile eşleştirmek
        Sh = code.GetComponent<Shooting>();

        moveCode = GameObject.FindGameObjectWithTag("RifleSoldier");

        pm = moveCode.GetComponent<PlayerMovement_>();
        Enemy = GameObject.FindGameObjectWithTag("Teror");
        Se = Enemy.GetComponent<ShootingEnemy>();



        //Shooting scriptimizdeki kodu eşleştiriyoruz
        rifle_sol = GameObject.FindGameObjectWithTag("RifleSoldier");
        //RifleSoldier etiketli oyun objesini rile_sol'a atıyourz
        knife_sol_render = GameObject.FindGameObjectWithTag("KnifeSoldier");
        //Tagi knife soldier olan nesnenin özelliklerini atadık
        // knife_sol_sr = knife_sol_render.GetComponent<SpriteRenderer>();
        //Bos bir rendera knife soldierın renderinin özelliklerini atadık
        //atamaları yapıyoruz amk biliyoruz zaten uğraştırıyorsunuz
        knife_pc_ob = GameObject.FindGameObjectWithTag("KnifeSoldier");
        // knife_pc = knife_pc_ob.GetComponent<PolygonCollider2D>();
    }



    void Update()
    {
        
        if (pm.health <= 0)
        {
            Debug.Log("Öldüm");
        }
        if (Se.EnemyHealth <= 0)
        {
            Debug.Log("Öldü");
        }
        if (pm.movement.x > 0 || pm.movement.y > 0 || pm.movement.x < 0 || pm.movement.y < 0)
        {
            if (slowMoKontrol)
            {
                Time.timeScale = normalTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                slowMoKontrol = false;
            }
        }
        else
        {
            if (!slowMoKontrol)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                slowMoKontrol = true;

            }

        }
        
        //if (Sh.mermiSayisi>=30)
        //{
            
        //    //rifle_sol.SetActive(false);

        //    //knife_sol_sr.enabled = true;
        //    //knife_pc.enabled = true;
        //}
        //30 mermiden sonra rifle_sol yok oluyor bıçaklı geliyor
       
        

    }

}
