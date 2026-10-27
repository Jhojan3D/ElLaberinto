using UnityEngine;
using UnityEngine.AI;

public class EnemigoQuieto : IAEnemigos
{
    private NavMeshAgent navMeshAgent;
    public override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void EstadoVigilante()
    {
        base.EstadoVigilante();
        navMeshAgent.SetDestination(transform.position);
    }
    public override void EstadoSiguendo()
    {
        base.EstadoSiguendo();
        navMeshAgent.SetDestination(playerTransform.position);
    }
    public override void EstadoAtacando()
    {
        base.EstadoAtacando();
        navMeshAgent.SetDestination(transform.position);
    }
    



}
