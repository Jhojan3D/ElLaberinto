using UnityEngine;

public class SistemaDeVidaEne1 : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;
    public void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(float danioRecibido)
    {
        vidaActual -= danioRecibido;
        Debug.Log("Daño Recibido del Jugador" + danioRecibido);
        if (vidaActual <= 0f)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        Destroy(gameObject);
    }
}
