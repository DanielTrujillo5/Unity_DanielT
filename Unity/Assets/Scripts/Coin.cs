using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Variable estática para el contador (compartida entre todas las monedas)
    public static int contadorMonedas = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu "Sphere" tenga el tag "Player"
        {
            contadorMonedas++; // Aumenta el contador
            Debug.Log("Monedas recolectadas: " + contadorMonedas); // Muestra en consola
            Destroy(gameObject); // Destruye la moneda
        }
    }
}