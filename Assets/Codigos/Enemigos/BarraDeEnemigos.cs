using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnemigos : MonoBehaviour
{
    private Image image;
    public float vidaMax;
    public GameObject[] enemigos;
    SistemaDeVidaEne1 sistemaDeVidaEne1;

    private void Awake()
    {
        image = GetComponent<Image>();
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        
        
    }
    private void Start()
    {
        foreach(GameObject enemigo in enemigos)
        {
            sistemaDeVidaEne1 = enemigo.GetComponent<SistemaDeVidaEne1>();
            vidaMax = sistemaDeVidaEne1.vidaMaxima;
        }
        
    }
    private void Update()
    {
        
            image.fillAmount = sistemaDeVidaEne1.vidaActual / vidaMax;  
           
    }
}
