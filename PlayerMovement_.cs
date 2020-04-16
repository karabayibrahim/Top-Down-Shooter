using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_ : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;
    float ek = 1.5f;
    public float health = 100;
    
   
    
    //Karakter hareket hızı

    public Rigidbody2D rb;
    
    //Cisimin fiziği olması için gereken fonksiyon;

    public Vector2 movement;
    
    //hareketi vector2 olarak tanımladık
    Vector2 mousePos;
    //fare konumunu vector2 de tanımladık

    public Camera cam;
    //kameramızı tanımladık



    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //wasd girdisinde x ve y ekseninde hareketi sağlıyor

        

        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetFloat("Speed", Mathf.Abs(movement.y));






        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        //Farenin pozisyonunu alıyoruz  

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime*ek);
        //Hareket hızını hesaplıyoruz  

       Vector2 lookDir = mousePos - rb.position;
       float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; 

       rb.rotation = angle; 
            
    }
}
