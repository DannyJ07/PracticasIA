using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SMovimiento
{
    public float rotacion;
    public float tiempo;
    public float velocidad;
    public float velRotacion;

    public SMovimiento(float pRotacion, float pTiempo, float pVelocidad, float pVelRotacion)
    {
        rotacion = pRotacion;
        tiempo = pTiempo;
        velocidad = pVelocidad;
        velRotacion = pVelRotacion;
    }
}

public class MovPatron : MonoBehaviour
{
    private int cantidadPasos;
    private List<SMovimiento> patron = new List<SMovimiento>();
    private float Tiempo = 0;
    private int indice = 0;
    private Vector3 direccion;

    private Vector3 posicionInicial; // Variable para almacenar la posición inicial
    private bool enMovimiento = false; // Bandera para controlar el estado de movimiento

    public Transform meta; // Referencia a la meta de llegada
    public float distanciaMeta = 0.5f; // Distancia mínima para considerar que ha llegado a la meta

    void Start()
    {
        // Guarda la posición inicial del objeto
        posicionInicial = transform.position;
    }

    private void Update()
    {
        // Si el objeto no está en movimiento, no hacer nada
        if (!enMovimiento)
        {
            return;
        }

        // Si el objeto ha llegado a la meta, no seguir moviéndolo
        if (Vector3.Distance(transform.position, meta.position) <= distanciaMeta)
        {
            Debug.Log("¡Meta alcanzada!");
            return;
        }

        Tiempo += Time.deltaTime;

        if (Tiempo > patron[indice].tiempo)
        {
            Tiempo = 0;
            indice++;

            if (indice >= cantidadPasos)
            {
                indice = 0;
            }
        }

        direccion = Quaternion.AngleAxis(patron[indice].rotacion, Vector3.up) * transform.forward;
        Quaternion rotOjetivo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotOjetivo, patron[indice].velRotacion * Time.deltaTime);
        transform.Translate(transform.forward * patron[indice].velocidad * Time.deltaTime);
    }

    // Métodos para cada patrón
    public void Patron1()
    {
        patron.Clear();
        patron.Add(new SMovimiento(30, 2, 5, 3));
        patron.Add(new SMovimiento(-30, 2, 5, 2));
        patron.Add(new SMovimiento(0, 3, 5, 0));
        patron.Add(new SMovimiento(0, 2, 2, 0));
        patron.Add(new SMovimiento(15, 5, 0, 5));
        ResetPatron();
        enMovimiento = true; // Habilita el movimiento
    }

    public void Patron2()
    {
        patron.Clear();
        patron.Add(new SMovimiento(45, 1, 4, 4));
        patron.Add(new SMovimiento(-45, 1, 4, 4));
        patron.Add(new SMovimiento(0, 4, 6, 0));
        ResetPatron();
        enMovimiento = true; // Habilita el movimiento
    }

    public void Patron3()
    {
        patron.Clear();
        patron.Add(new SMovimiento(0, 2, 10, 0));
        patron.Add(new SMovimiento(180, 1, 5, 2));
        patron.Add(new SMovimiento(90, 2, 8, 3));
        ResetPatron();
        enMovimiento = true; // Habilita el movimiento
    }

    public void VolverPuntoInicial()
    {
        transform.position = posicionInicial; // Regresa el objeto a la posición inicial
        transform.rotation = Quaternion.identity; // Opcional: Resetea la rotación del objeto
        enMovimiento = false; // Detiene el movimiento
    }

    private void ResetPatron()
    {
        cantidadPasos = patron.Count;
        indice = 0;
        Tiempo = 0;
    }
}

