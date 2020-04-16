using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject MedKit;
    public MedKit Mk;
    public GameObject Player;
    public  PlayerMovement_ Pm;
    public GameObject Enemy;
    public ShootingEnemy Se;
    public float maxhealth = 100;
    public SimpleHealthBar healthBar;
    public float PlayerHealth = 100;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("RifleSoldier");
        Pm = Player.GetComponent<PlayerMovement_>();
        Enemy = GameObject.FindGameObjectWithTag("Teror");
        Se = Enemy.GetComponent<ShootingEnemy>();
        MedKit = GameObject.FindGameObjectWithTag("Med");
        Mk = MedKit.GetComponent<MedKit>();
        

    }
    private void Update()
    {
        if (PlayerHealth <= 50)
        {
            healthBar.UpdateColor(Color.red);
        }
        else
        {
            healthBar.UpdateColor(Color.green);
        }
    }
    // Update is called once per frame
    public float Playertakedamage(float health)
    {
        health -= Se.EnemyDamage;
        healthBar.UpdateBar(health, maxhealth);
        
        return health;
        
    }
    public float PlayerGainHealth(float health)
    {
        health += Mk.HealthGive;
        healthBar.UpdateBar(health, maxhealth);
        return health;

    }
}
