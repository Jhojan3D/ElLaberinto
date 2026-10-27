using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoVigia : IAEnemigos
{
    private NavMeshAgent navMeshAgent;
    public List<Transform> puntosTransforms = new List<Transform>();
    public float distanciaLLegada;
    public int index;
    public override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public override void EstadoVigilante()
    {
        base.EstadoVigilante();
        navMeshAgent.SetDestination(puntosTransforms[index].position);
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance <= distanciaLLegada)
        {
            index++;
            if(index >=puntosTransforms.Count)
            {
                index = 0;
            }
        }
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

   
