using UnityEngine;
using UnityEngine.UI;

public class BarraDeEnemigos : MonoBehaviour
{
     public GameObject[] images;
     public float vidaMax;
     public GameObject[] enemigos;
     SistemaDeVidaEne1 sistemaDeVidaEne1;
     public Image image1;
    

     private void Awake()
     {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        images = GameObject.FindGameObjectsWithTag("BarraDeVida");
         

     }
     private void Start()
     {
 
        foreach (GameObject enemigo in enemigos)
         {
             sistemaDeVidaEne1 = enemigo.GetComponent<SistemaDeVidaEne1>();
             vidaMax = sistemaDeVidaEne1.vidaMaxima;
         }
        foreach(GameObject image in images)
        {
            image1 = image.GetComponent<Image>();
        }
        

     }
     private void Update()
     {

             image1.fillAmount = sistemaDeVidaEne1.vidaActual / vidaMax;  

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
