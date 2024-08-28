using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorH : MonoBehaviour
{
    public Contador contador;
    void Start()
    {
        contador = GameObject.FindGameObjectWithTag("Player").GetComponent<Contador>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            contador.Cantidad = contador.Cantidad + 1;
            Destroy(gameObject);

        }

    }
}
