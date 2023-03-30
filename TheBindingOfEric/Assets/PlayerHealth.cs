// using UnityEngine;
// using UnityEngine.SceneManagement;


// public class PlayerHealth : MonoBehaviour
// {
//     public int startingHealth = 100; // La salud inicial del jugador.
//     private int currentHealth; // La salud actual del jugador.
//     //public GameObject gameOverScreen; // Referencia a la pantalla de GameOver que se mostrará cuando el jugador pierda.

//     private void Start()
//     {
//         currentHealth = startingHealth;
//     }

//     // Este método se llama cuando el jugador colisiona con otro objeto.
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.gameObject.tag == "Enemy")
//         {
//             Debug.Log("Colisión detectada con objeto: " + other.gameObject.name);
//             Debug.Log("Se ha cargado la escena: " + SceneManager.GetActiveScene().name);

//             currentHealth = 0; // Reduce la salud del jugador a cero.
//             SceneManager.LoadScene("GameOver");
//              // Muestra la pantalla de GameOver.
//             Time.timeScale = 0f; // Pausa el juego.
//         }
//     }
// }
