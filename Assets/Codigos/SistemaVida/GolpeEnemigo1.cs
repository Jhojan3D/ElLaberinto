using UnityEngine;

public class GolpeEnemigo1 : MonoBehaviour
{
    public float danioGolpe;
    public Transform playerTransform;
    public float distanciaPlayer;
    public float rangoDeDanio;
    [Header("Sonidos")]
    public AudioClip golpeSonido;
    public AudioClip dañoSonido;

    public void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void InpactoGolpe()
    {
        if(playerTransform == null)
        {
            return;
        }
        distanciaPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanciaPlayer <= rangoDeDanio)
        {
            SistemaDeVida sistemaDeVida = playerTransform.GetComponent<SistemaDeVida>();
            if(sistemaDeVida == null)
            {
                return;
            }
            else
            {
                sistemaDeVida.RecibirDanio(danioGolpe);
                AudioManager.Instance.PlaySfx(golpeSonido);
            }
            
        }
    }
}
