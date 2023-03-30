 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;
 public class Movimiento : MonoBehaviour
 {
     public float velocidadMovimiento = 1f; // Velocidad de movimiento del jugador
     public float velocidadRotacion = 200f; // Velocidad de rotación del jugador
     public GameObject balaPrefab; // Prefab de la bala
     public Transform puntoAparicionBala; // Punto de aparición de la bala
     public float fireRate = 0.5f; // Cantidad de tiempo entre cada disparo
     private float nextFire = 0.0f; // Tiempo en el que se puede realizar el próximo disparo
     private Disparo disparo; // Referencia al componente Disparo en el objeto del jugador
     private bool tocoPared = false;
     public Rigidbody2D rb;
     //private Movimiento jug = FindGameObjectsWithTag("Player")
     void Start()
     {
         disparo = GetComponent<Disparo>();
     }
     // Actualizar el movimiento y la rotación del jugador
     private void Update()
     {
        if(tocoPared == true){
            return;
        }
         // Obtener la entrada del teclado para el movimiento horizontal y vertical
         float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
         float movimientoVertical = Input.GetAxisRaw("Vertical");
         // Calcular la dirección del movimiento
         Vector2 direccionMovimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;
         // Calcular la velocidad de movimiento y aplicarla al jugador
         float velocidadActualMovimiento = direccionMovimiento.magnitude * velocidadMovimiento;
      
        transform.Translate(direccionMovimiento * velocidadActualMovimiento * Time.deltaTime);
     if (Input.GetAxis("HorizontalShoot") != 0 || Input.GetAxis("VerticalShoot") != 0)
     {
         float angle = Mathf.Atan2(Input.GetAxis("VerticalShoot"), Input.GetAxis("HorizontalShoot")) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
         {
             nextFire = Time.time + fireRate;
             disparo.Disparar();
         }
     }
     }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            SceneManager.LoadScene("GameOver");
        }
        else{
        float rebote = 200f;
        tocoPared = true;
        //Debug.Log(collision);
        rb.AddForce(collision.contacts[0].normal * rebote);        
        Invoke("pararRebote",0.5f);
        }

    }
    void pararRebote (){
        tocoPared = false;
    }
}
