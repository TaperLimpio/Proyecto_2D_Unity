using UnityEngine;
using TMPro; // Para poder manejar el TextMeshPro

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coinCount = 0;

    // Método para aumentar el contador
    public void AddCoin()
    {
        coinCount++; // Sumar una moneda
        coinText.text = "Contador de monedas: " + coinCount.ToString(); // Actualizar el texto del UI
    }

    // Método para detectar colisiones con monedas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin")) // Comprobar si es una moneda
        {
            
            Destroy(collision.gameObject); // Destruir la moneda cuando es recogida
        }
    }
}
