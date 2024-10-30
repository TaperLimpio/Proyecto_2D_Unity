using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    public Image vidaBarra;  // Asigna la imagen de la barra de vida en el Inspector
    public float vidaMaxima = 100f;
    private float vidaActual;

    void Start()
    {
        vidaActual = vidaMaxima; // Inicializa la vida actual al máximo
        ActualizarBarraVida();
    }

    void Update()
    {
        // Para pruebas, puedes hacer daño o curar al presionar teclas
        if (Input.GetKeyDown(KeyCode.Space)) // Presiona la barra espaciadora para recibir daño
        {
            RecibirDanio(10f);
        }

        if (Input.GetKeyDown(KeyCode.C)) // Presiona 'C' para curar
        {
            Curar(10f);
        }
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Asegura que no se pase de 0
        ActualizarBarraVida();
    }

    public void Curar(float cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima); // Asegura que no se pase del máximo
        ActualizarBarraVida();
    }

    private void ActualizarBarraVida()
    {
        vidaBarra.fillAmount = vidaActual / vidaMaxima; // Actualiza el valor de la barra
    }
}
