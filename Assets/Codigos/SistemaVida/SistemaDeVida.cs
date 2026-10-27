using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeVida : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;
    [Header("Escena A Reiniciar")]
    public string nuevaEscena;
    public void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float danioRecibido)
    {
        vidaActual -= danioRecibido;
        Debug.Log("Daño Recibido del enemigo" + danioRecibido);
        if(vidaActual <= 0f)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nuevaEscena);
    }
}
