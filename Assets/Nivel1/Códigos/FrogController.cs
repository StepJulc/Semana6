using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;

public class FrogController : MonoBehaviour
{
    public int cantbal = 0;

    
    //bala
    public GameObject bala;
    private Transform balaTransform;
    private bool balaExiste = false;
    
    //audio
    AudioSource audioSource;
    public AudioClip saltoclip;
    
    

    //Correr y saltar
    public float runSpeeed = 10;
    public float jumpSpeed = 8;
   
    // para el doble salto y podersaltardoble
    public float doubleJumpSpeed = 15;
    private bool canDoubleJump;
    
    Rigidbody2D rb2D;
    
    //Mirar a un lado o a otro
    public SpriteRenderer spriteRenderer;

    Animator animacion;
    public int Idle;
    public int Correr;
    public int Saltar;
    public int Atacar;
    public int Disparar;
    public int Deslizar;
    public int Morir;
    
    private bool bandera = false;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }
    
    
    //para el doble salto
    void Update()
    {
        //salto normal
        if (Input.GetKey("space") )
        {
            audioSource.PlayOneShot(saltoclip);
            
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                
                ChangeAnimation(Saltar);
                
            }
            //salto doble
            else
            {
                //si presiomo espacio y luego M salta doble
                if (Input.GetKeyDown("m") )
                {
                    if (canDoubleJump)
                    {
                       
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
           
        }
    }//cierre salto

    void FixedUpdate()
    {
        //bandare para desaparecer al morir
        if (bandera == false)
        {
            //derecha
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb2D.velocity = new Vector2(runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = false;
                //bloqueamos mirar de un lado a otro para q el transform funcione
                
     
                
                ChangeAnimation(Correr);
            }

            //izquierda
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2D.velocity = new Vector2(-runSpeeed, rb2D.velocity.y);
                spriteRenderer.flipX = true;
               //bloqueamos mirar de un lado a otro para q el transform funcione
                
            
                
                
                ChangeAnimation(Correr);
            }

            else
            {
                rb2D.velocity = new Vector2(0, rb2D.velocity.y);
                ChangeAnimation(Idle);
            }


        }
        
        if (Input.GetKey("z"))
        {
            ChangeAnimation(Atacar);
        }
        
        if (Input.GetKey("x"))
        {
            ChangeAnimation(Deslizar);
        }

        if (Input.GetKey("c"))
        {
            ChangeAnimation(Morir);
            //destruir jugador al morir
            bandera = true;
            Destroy(gameObject, 0.8f);
        }
        
        if (Input.GetKeyUp("v") )
        {
           
                Debug.Log("Dsiparo");
                balaExiste = true;
                var position = transform.position;
                var x = position.x + 1;
                var newPosition = new Vector3(x, position.y, position.z);
        
                GameObject balaGenerada = Instantiate(bala, newPosition, Quaternion.identity);
                balaTransform = balaGenerada.transform;
                cantbal += 5;
                ChangeAnimation(Disparar);
            
           
        }
    }
    private void ChangeAnimation(int animat)
    {
        animacion.SetInteger("Estado",animat);
    }
    
 
    }

