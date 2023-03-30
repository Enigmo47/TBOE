using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDisparo : MonoBehaviour
{
    public float speed = 5f; // velocidad de movimiento del jugador
    public GameObject disparoPrefab; // prefab del disparo
    public Transform puntoDisparo; // posición donde se genera el disparo
    public float frecuenciaDisparo = 1f; // frecuencia de disparo en segundos
    private float tiempoUltimoDisparo = 0f; // tiempo en segundos desde el último disparo

    // Update is called once per frame
    void Update()
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime);

        // Rotación del jugador
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        transform.up = mousePos - transform.position;

        // Disparo
        if (Input.GetMouseButton(0) && Time.time - tiempoUltimoDisparo > frecuenciaDisparo)
        {
            tiempoUltimoDisparo = Time.time;
            GameObject disparo = Instantiate(disparoPrefab, puntoDisparo.position, Quaternion.identity);
            disparo.transform.up = transform.up;
        }
    }
}
