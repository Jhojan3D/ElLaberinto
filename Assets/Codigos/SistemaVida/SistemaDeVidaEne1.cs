using UnityEngine;

public class SistemaDeVidaEne1 : MonoBehaviour
{
    public float vidaMaxima;
    public float vidaActual;
    public float sumarVidaPlayer;
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
        SistemaDeVida sistemaDeVida = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaDeVida>();
        sistemaDeVida.CargarVida(sumarVidaPlayer);
        Destroy(gameObject);
    }
}
