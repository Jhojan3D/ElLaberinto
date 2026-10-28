using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Image image;
    public float vidaMax;
    public SistemaDeVida sistemaDeVida;
    private void Awake()
    {
        image = GetComponent<Image>();
        sistemaDeVida = GameObject.FindGameObjectWithTag("Player").GetComponent<SistemaDeVida>();
    }
    private void Start()
    {
        vidaMax = sistemaDeVida.vidaMaxima;
    }
    private void Update()
    {
        image.fillAmount = sistemaDeVida.vidaActual / vidaMax;
    }
    
}
