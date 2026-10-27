using UnityEngine;
using UnityEngine.AI;

public class EnemigoQuieto : IAEnemigos
{
    private NavMeshAgent navMeshAgent;
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
        navMeshAgent.SetDestination(transform.position);
        animator.SetBool("IsRunning", false);
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
        if(Time.time > tiempoActualAtaque)
        {
            animator.SetTrigger("IsAttack");
            tiempoActualAtaque = Time.time + tiempoEsperaAtaque;
        }
    }
    



}
