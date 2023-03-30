using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sala : MonoBehaviour
{
    public GameObject enemyPrefab;

    private bool hasEnemy = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprueba si el objeto que entra en la sala es el jugador y no hay un enemigo ya presente
        if (other.CompareTag("Player") && !hasEnemy)
        {
            // Crea una instancia del enemigo en la sala y marca la sala como que tiene un enemigo
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            hasEnemy = true;
        }
    }

    public void OnEnemyDestroyed()
    {
        // Marca la sala como que no tiene un enemigo una vez que el enemigo es destruido
        hasEnemy = false;
    }
}
