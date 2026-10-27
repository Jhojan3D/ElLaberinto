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
            SistemaDeVida sistemaDeVida = enemigoTransform.GetComponent<SistemaDeVida>();
            if (sistemaDeVida == null)
            {
                return;
            }
            else
            {
                sistemaDeVida.RecibirDanio(danioGolpe);
            }

        }
    }
}
