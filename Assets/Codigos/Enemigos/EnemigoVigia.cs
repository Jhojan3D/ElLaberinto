using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoVigia : IAEnemigos
{
    private NavMeshAgent navMeshAgent;
    public List<Transform> puntosTransforms = new List<Transform>();
    public float distanciaLLegada;
    public int index;
    private Animator animator;
    public float tiempoEsperaAtaque;
    public float tiempoActualAtaque;
    public override void Awake()
    {
        base.Awake();
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    public override void EstadoVigilante()
    {
        base.EstadoVigilante();
        navMeshAgent.SetDestination(puntosTransforms[index].position);
        animator.SetBool("IsRunning", true);
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
        animator.SetBool("IsRunning", true);


    }
    public override void EstadoAtacando()
    {
        base.EstadoAtacando();
        navMeshAgent.SetDestination(transform.position);
        animator.SetBool("IsRunning", false);
        if (Time.time > tiempoActualAtaque)
        {
            animator.SetTrigger("IsAttack");
            tiempoActualAtaque = Time.time + tiempoEsperaAtaque;
        }


    }
}

   
