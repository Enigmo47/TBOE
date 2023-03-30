// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemigosEnSala : MonoBehaviour
// {
//     public List<Enemigos> enemigosEnSala;

//     public void Start()
//     {
//         enemigosEnSala = new List<Enemigos>();

//         // Buscamos todos los objetos de enemigos en la sala
//         GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

//         // Agregamos todos los enemigos encontrados a la lista
//         foreach (GameObject enemigo in enemigos)
//         {
//             Enemigos enemigoComponente = enemigo.GetComponent<Enemigos>();
//             if (enemigoComponente != null)
//             {
//                 enemigosEnSala.Add(enemigoComponente);
//             }
//         }

//         // Actualizamos la lista de enemigos
//         ActualizarListaEnemigos();
//     }

//     public void ActualizarListaEnemigos()
//     {
//         // Recorremos la lista de enemigos en la sala
//         foreach (Enemigos enemigo in enemigosEnSala)
//         {
//             // Si el jugador está en rango de ataque del enemigo, lo atacamos
//             if (enemigo.JugadorEnRangoDeAtaque())
//             {
//                 enemigo.AtacarJugador();
//             }
//             // Si el jugador está fuera de rango de ataque, detenemos el ataque
//             else if (enemigo.JugadorFueraDeRangoDeAtaque())
//             {
//                 enemigo.DetenerAtaqueJugador();
//             }
//         }
//     }
// }
