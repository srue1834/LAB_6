using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2D : MonoBehaviour
{
    float velocidad = 2;
    private float movimiento;
    private Rigidbody2D rb;
    public Sprite cambioSprite;

    public GameObject enemigo;
     

    // Start is called before the first frame update
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        movimiento = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidad, rb.velocity.y);

        //se reiniciara el juego cuando el objeto caiga de la plataforma
        if(rb.position.y < -6f)
        {
            FindObjectOfType<Manager>().gameOver();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Saltar();
        }

        cambioLado();

        poder();

        
    }

    void Saltar()
    {
        //si salta hacia arriba su velocidad es positiva y hacia abajo es negativa
        if (rb && Mathf.Abs(rb.velocity.y) < 0.10f)
        {
            //impulse hace que use toda la fuerza
            rb.AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);

        }
    }

    //se cambiara el lado del sprite cuando se oprime la flecha derecha o izquiera
    void cambioLado()
    {
        Vector3 escala = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            escala.x = -0.7f;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            escala.x = 0.7f;
        }

        transform.localScale = escala;

    }


    //cuando el player toque al enemigo se destruira
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemigo"))
        {
            Destroy(gameObject);
            FindObjectOfType<Manager>().gameOver();

        }

        if (collider.CompareTag("PowerUp"))
        {
            Destroy(collider.gameObject);
            FindObjectOfType<Manager>().coins++;
        }

    }

    //este le otorga al player el poder de eliminar a su enemigo 
    private void poder()
    {
        if(FindObjectOfType<Manager>().coins == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cambioSprite;
            enemigo.GetComponent<BoxCollider2D>().tag = "PowerUp";
        }
    }
}

