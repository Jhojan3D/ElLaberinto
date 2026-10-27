using UnityEngine;

public class GolpePlayer : MonoBehaviour
{
    public float danioGolpe;
    public Transform enemigoTransform;
    public float distanciaEnemigo;
    public float rangoDeDanio;

    public void Awake()
    {
        enemigoTransform = GameObject.FindGameObjectWithTag("Enemigo").transform;
    }
    public void InpactoGolpe()
    {
        if (enemigoTransform == null)
        {
            return;
        }
        distanciaEnemigo = Vector3.Distance(transform.position, enemigoTransform.position);
        if (distanciaEnemigo <= rangoDeDanio)
        {
            SistemaDeVidaEne1 sistemaDeVidaEne1 = enemigoTransform.GetComponent<SistemaDeVidaEne1>();
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
