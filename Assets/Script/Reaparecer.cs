using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaparecer : MonoBehaviour
{
    public float tiempoEspera = 15f;
    public Vector3 nuevaPosicion;

    void Start()
    {
        // Inicia la corrutina que espera 15 segundos antes de mover el objeto
        StartCoroutine(MoverDespuesDeTiempo(tiempoEspera));
    }
    System.Collections.IEnumerator MoverDespuesDeTiempo(float tiempo)
    {
        while (true) // Bucle infinito
        {
            // Espera el tiempo especificado
            yield return new WaitForSeconds(tiempo);

            // Calcula una nueva posición aleatoria dentro del plano de escala 10x1x10
            float nuevoX = Random.Range(-5f, 5f);
            float nuevoZ = Random.Range(-5f, 5f);
            nuevaPosicion = new Vector3(nuevoX, transform.position.y, nuevoZ);

            // Mueve el objeto a la nueva posición
            transform.position = nuevaPosicion;
        }
    }
}
