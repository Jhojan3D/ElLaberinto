using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnemigos : MonoBehaviour
{
     public float vidaMax;
     public GameObject[] enemigos;
     SistemaDeVidaEne1 sistemaDeVidaEne1;
     Image image;
    

     private void Awake()
     {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        image = GetComponent<Image>();
     }
     private void Start()
     {
 
        foreach (GameObject enemigo in enemigos)
         {
             sistemaDeVidaEne1 = enemigo.GetComponent<SistemaDeVidaEne1>();
             vidaMax = sistemaDeVidaEne1.vidaMaxima;
         }


     }
     private void Update()
     {

            // image.fillAmount = sistemaDeVidaEne1.vidaActual / vidaMax; 

     }
    
    /*
    private Image image;
    public float vidaMax;
    SistemaDeVidaEne1 sistemaDeVidaEne1;
    private void Awake()
    {
        image = GetComponent<Image>();
        sistemaDeVidaEne1 = GameObject.FindGameObjectWithTag("Enemigo").GetComponent<SistemaDeVidaEne1>();
    }
    private void Start()
    {
        vidaMax = sistemaDeVidaEne1.vidaMaxima;
    }
    private void Update()
    {
        image.fillAmount = sistemaDeVidaEne1.vidaActual / vidaMax;
    }
    */
}
