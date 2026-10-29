using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnemigos : MonoBehaviour
{
    private Image image;
    public float vidaMax;
    public SistemaDeVidaEne1 sistemaDeVidaEne1;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void Start()
    {
        if( sistemaDeVidaEne1 != null)
        {
        vidaMax = sistemaDeVidaEne1.vidaMaxima;
        }
    }
    private void Update()
    {
        image.fillAmount = sistemaDeVidaEne1.vidaActual / vidaMax;
    }

}
