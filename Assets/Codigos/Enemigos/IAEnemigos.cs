using UnityEngine;

public enum EstadosEnemigo
{
    estaVigilando,
    estaSiguiendo,
    estaAtacando
}
public class IAEnemigos : MonoBehaviour
{
    public EstadosEnemigo estadoActual;
    public float distanciaAtacar;
    public float distanciaSiguiendo;
    public float distanciaEscapar;
    public Transform playerTransform;
    public float distanciaPlayer;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtacar);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaSiguiendo);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaEscapar);
    }
    public virtual void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void Start()
    {
        estadoActual = EstadosEnemigo.estaVigilando;
    }
    public virtual void Update()
    {
        distanciaPlayer = Vector3.Distance(transform.position, playerTransform.position);
        GestorDeEstados();
    }
    private void GestorDeEstados()
    {
        switch(estadoActual)
        {
            case EstadosEnemigo.estaVigilando:
                EstadoVigilante();
                break;
            case EstadosEnemigo.estaSiguiendo:
                EstadoSiguendo();
                break;
            case EstadosEnemigo.estaAtacando:
                EstadoAtacando();
                break;
        }
    }
    private void CambioDeEstado(EstadosEnemigo nuevoEstado)
    {
        estadoActual = nuevoEstado;
    }
    public virtual void EstadoVigilante()
    {
        if(distanciaPlayer < distanciaSiguiendo)
        {
            CambioDeEstado(EstadosEnemigo.estaSiguiendo);
        }
    }
    public virtual void EstadoSiguendo()
    {
        if(distanciaPlayer < distanciaAtacar)
        {
            CambioDeEstado(EstadosEnemigo.estaAtacando);
        }
        else if(distanciaPlayer > distanciaEscapar)
        {
            CambioDeEstado(EstadosEnemigo.estaVigilando);
        }

    }
    public virtual void EstadoAtacando()
    {
        if(distanciaPlayer > distanciaAtacar)
        {
            CambioDeEstado(EstadosEnemigo.estaSiguiendo);
        }
    }

}
