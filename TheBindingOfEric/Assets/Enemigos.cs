 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class Enemigos : MonoBehaviour
 {
     public float velocidadMovimiento = 3f;
     public float rangoVision = 5f;
     public float distanciaAtaque = 1f;
     public int vidaInicial = 3;
     public int danoAtaque = 1;
     private Transform jugador;
     private Rigidbody2D rb;
     //private Animator anim;
     private int vida;
     private bool estaVivo = true; // Variable para indicar si el enemigo está vivo o muerto
     void Start()
     {
         jugador = GameObject.FindGameObjectWithTag("Player").transform;
         rb = GetComponent<Rigidbody2D>();
         //anim = GetComponent<Animator>();
         vida = vidaInicial; // Inicializar la variable vida con el valor de vidaInicial
     }
     void Update()
     {
         if (estaVivo) // Comprobar si el enemigo está vivo antes de hacer nada
         {
             // Calcular la distancia entre el enemigo y el jugador
             float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
             if (distanciaJugador < rangoVision)
             {
                 // El jugador está dentro del rango de visión
                 if (distanciaJugador > distanciaAtaque)
                 {
                     // El jugador está fuera del rango de ataque, moverse hacia él
                     Vector2 direccion = (jugador.position - transform.position).normalized;
                     rb.velocity = direccion * velocidadMovimiento;
                     // Girar el sprite para que mire hacia el jugador
                     if (direccion.x > 0)
                     {
                         transform.localScale = new Vector2(-1f, 1f);
                     }
                     else if (direccion.x < 0)
                     {
                         transform.localScale = new Vector2(1f, 1f);
                     }
                 }
                 else
                 {
                     // El jugador está dentro del rango de ataque, detenerse y atacar
                     rb.velocity = Vector2.zero;
                     //anim.SetTrigger("Atacar");
                 }
             }
             else
             {
                 // El jugador está fuera del rango de visión, detenerse
                 rb.velocity = Vector2.zero;
             }
         }
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.CompareTag("Bullet") && estaVivo) // Comprobar si el enemigo está vivo antes de recibir daño
         {
             // Si choca con una bala, reducir la vida del enemigo
             // Obtener el componente Disparo de la bala
             Disparo disparo = collision.gameObject.GetComponent<Disparo>();
             // Reducir la vida del enemigo según el daño del disparo
             recibirDano(disparo.dano);
             // Destruir la bala
             Destroy(collision.gameObject);
         }
     }
     // Método para recibir daño
public void recibirDano(int cantidadDano)
{
    vida -= cantidadDano;
    if (vida <= 0)
    {
        // Si la vida llega a cero, destruir al enemigo y llamar al método EnemigoDestruido de GinScreen
        GameObject winScreenObject = GameObject.FindWithTag("win");
        if (winScreenObject != null)
        {
            win winScreen = winScreenObject.GetComponent<win>();
            if (winScreen != null)
            {
                winScreen.EnemigoDestruido();
            }
        }

        Destroy(gameObject);
        estaVivo = false; // Establecer la variable estaVivo a false para evitar errores
    }
}

 private void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.gameObject.CompareTag("Bullet") && estaVivo) // Comprobar si el enemigo está vivo antes de recibir daño
     {
         // Si la bala choca con el enemigo, reducir la vida del enemigo
         // Obtener el componente Disparo de la bala
         Disparo disparo = collision.gameObject.GetComponent<Disparo>();
         // Reducir la vida del enemigo según el daño del disparo
         recibirDano(1);
         // Destruir la bala
         Destroy(collision.gameObject);
     }
     // else if (collision.gameObject.CompareTag("Player"))
     // {
     //     // Si el enemigo choca con el jugador, infligir daño al jugador
     //     jugador.GetComponent<Jugador>().recibirDano(danoAtaque);
     // }
 }
 }