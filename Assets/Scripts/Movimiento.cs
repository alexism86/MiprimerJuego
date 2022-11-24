using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables globales
    public float velocidad;
    public float fuerza_Salto;
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    
    
    //Header animaciones
    [Header("Animacion")]
    private Animator anim;
    
    void Start()
    {
        //Inicializamos
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        velocidad = 10f;
        //animator
        anim = GetComponent<Animator>();
        
    }
    
    
    //Dirección del movimiento
    public bool moveRight = true;
    
    // Update is called once per frame
    void Update()
    {
        //movimiento
        moveCharacter();
        //aplicar animaciones
        anim.SetFloat("Horizontal", Mathf.Abs(rigidbody.velocity.x));
    }
    //Funcion para mover el personaje 2d
    void moveCharacter()
    {
        //Movimiento en el eje x
        float horizontal = Input.GetAxis("Horizontal");
        rigidbody = GetComponent<Rigidbody2D>();
        
        //Movemos el personaje en X
        rigidbody.velocity = new Vector2(horizontal * velocidad, rigidbody.velocity.y);
        orientacionCharacter(horizontal);
        
    }
    
    
    //Gestionar la orientacion del personaje
    void orientacionCharacter(float horizontal)
    {
        //Si el personaje se mueve a la derecha
        if ((moveRight==true && horizontal<0) || (moveRight == false && horizontal > 0))
        { 
            //Lo debemos voltear
            moveRight = !moveRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }
    }
    
      
}
