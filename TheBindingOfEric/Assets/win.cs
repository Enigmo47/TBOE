using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public int enemigosDestruidos = 0;

    void Start()
    {
        // Asegúrate de que enemigosDestruidos se inicialice en cero al comienzo del juego
        enemigosDestruidos = 0;
    }

    public void EnemigoDestruido()
    {
        // Incrementa la variable enemigosDestruidos cada vez que se destruye un enemigo
        enemigosDestruidos++;

        // Si se destruyen 4 enemigos, cambia a la escena "WIN"
        if (enemigosDestruidos >= 4)
        { 
            SceneManager.LoadScene("WIN");
        }
    }
}
