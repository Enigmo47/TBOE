using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    public Transform jugador; // Referencia al objeto del jugador a seguir
    public Vector3 offset; // Offset de la cámara respecto al jugador

    void Update()
    {
        // Actualizar la posición de la cámara para que siga al jugador
        transform.position = jugador.position + offset;
    }
}
