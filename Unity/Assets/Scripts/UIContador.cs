using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIContador : MonoBehaviour
{
    public TextMeshProUGUI textoContador; // ← Este es el tipo correcto

    void Update()
    {
        if (textoContador != null) // Buena práctica para evitar errores
        {
            textoContador.text = "Monedas: " + Coin.contadorMonedas;
        }
    }
}