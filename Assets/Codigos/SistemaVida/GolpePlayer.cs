using UnityEngine;

public class GolpePlayer : MonoBehaviour
{
    public float danioGolpe;
    public float distanciaEnemigo;
    public float rangoDeDanio;
    public GameObject[] enemigos;

    public void Awake()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
    }
    public void InpactoGolpe()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        foreach(GameObject enemigo in enemigos)
        {
            distanciaEnemigo = Vector3.Distance(transform.position,enemigo.transform.position);
            if (distanciaEnemigo <= rangoDeDanio)
            {
                SistemaDeVidaEne1 sistemaDeVidaEne1 = enemigo.GetComponent<SistemaDeVidaEne1>();
                if (sistemaDeVidaEne1 == null)
                {
                    return;
                }
                else
                {
                    sistemaDeVidaEne1.RecibirDanio(danioGolpe);
                }

            }
        }
       
        
    }
}
