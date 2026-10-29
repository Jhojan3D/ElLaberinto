using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaDeVida : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;
    [Header("Escena A Reiniciar")]
    public string nuevaEscena;
    [Header("Sonido")]
    public AudioClip muertePlayer;
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
    public void CargarVida(float recibirVida)
    {
        vidaActual += recibirVida;
        Debug.Log("Recibir Vida" + recibirVida);
        if ( vidaActual>= 100f)
        {
            vidaActual = vidaMaxima;
        }
    }

    public void Muerte()
    {
        AudioManager.Instance.PlaySfx(muertePlayer);
        Time.timeScale = 1f;
        SceneManager.LoadScene(nuevaEscena);
    }
}
