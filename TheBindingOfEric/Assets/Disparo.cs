using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform puntoDisparo; // Referencia al objeto de aparición de la bala
    public GameObject prefabBala; // Prefab de la bala a instanciar
    public float fuerzaDisparo = 10f; // Fuerza con la que se disparará la bala
    public int dano = 1; // Daño causado por la bala

    // Método para disparar la bala
    public void Disparar()
    {
        // Instanciar la bala en el objeto de aparición
        GameObject nuevaBala = Instantiate(prefabBala, puntoDisparo.position, puntoDisparo.rotation);

        // Obtener el componente Rigidbody2D de la bala
        Rigidbody2D rbBala = nuevaBala.GetComponent<Rigidbody2D>();

        // Establecer la velocidad de la bala en la dirección del objeto de aparición
        rbBala.velocity = puntoDisparo.right * fuerzaDisparo;
    }
    
    // Método para detectar colisiones con la bala
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Llamar al método RecibirDano del enemigo si choca con un enemigo
        Enemigos enemigo = collision.GetComponent<Enemigos>();
        if (enemigo != null)
        {
            enemigo.recibirDano(dano);
        }

        // Destruir la bala
        Destroy(collision.gameObject);
    }
}
