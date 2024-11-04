using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVida : MonoBehaviour
{
    private Slider slider;
    private Vida vida; // Referencia a la clase Vida

    private void Start()
    {
        slider = GameObject.FindWithTag("Barradevida").GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("No se encontró el componente Slider en " + gameObject.name);
            return;
        }else{
            Debug.Log("Se logro encontrar el slider");
        }
        vida = GetComponent<Vida>();
        if (vida == null)
        {
            Debug.LogError("No se encontró el componente Vida en " + gameObject.name);
            return;
        }else{
            Debug.Log("Se logro encontrar el slider");
        }

        

        CambiarVidaMaxima(vida.getMaxVida());
        CambiarVidaActual(vida.getVida());

        // Suscribirse al evento de cambio de vida
        vida.OnVidaChanged += CambiarVidaActual;
    }

    private void Update(){
        
    }

    private void OnDestroy()
    {
        // Asegúrate de desuscribirte para evitar errores
        if (vida != null)
        {
            vida.OnVidaChanged -= CambiarVidaActual;
        }
    }

    public void CambiarVidaMaxima(int vidaMaxima)
    {
        slider.maxValue = vidaMaxima;
        slider.value = vida.getVida(); // Sincroniza el valor inicial con la vida actual
    }

    public void CambiarVidaActual(int vidaActual)
    {
        slider.value = vidaActual;
    }
}
