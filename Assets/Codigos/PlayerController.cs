using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction dashAction;
    private InputAction attackAction;
    private Rigidbody rb;
    private Camera camara;
    private Animator animator;

    [Header("Setting Move")]
    [SerializeField] private float speedMove;
    private Vector2 inputMove;
    [Header("Setting Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int jumpMax;
    [SerializeField] private int jumpCurrent;
    [Header("Setting Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private bool haveDash;
    [SerializeField] private float tiempoEsperaDash;
    [SerializeField] private float tiempoActualDash;
    [Header("Setting Attack")]
    [SerializeField] private bool haveAttack;
    [SerializeField] private float tiempoEsperaAttack;
    [SerializeField] private float tiempoActualAttack;
    [Header("Audios Clips")]
    [SerializeField] private AudioClip attackSonido;




    private void OnEnable()
    {
        if(inputActions != null)
        {
            inputActions.Enable();
            moveAction = inputActions.FindAction("Move");
            jumpAction = inputActions.FindAction("Jump");
            dashAction = inputActions.FindAction("Dash");
            attackAction = inputActions.FindAction("Attack");
        }
    }
    private void OnDisable()
    {
        if(inputActions!= null)
        {
            inputActions.Disable();
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        camara = Camera.main;
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        jumpCurrent = jumpMax;
        haveDash = true;
        tiempoActualDash = tiempoEsperaDash;
        haveAttack = true;
        tiempoActualAttack = tiempoEsperaAttack;
    }
    private void Update()
    {
        if(moveAction != null)
        {
            inputMove = moveAction.ReadValue<Vector2>();
            PlayerMove();
            AnimacionMover();
        }
        if(jumpAction != null)
        {
            PlayerJump();
        }
        if(dashAction != null)
        {
            PlayerDash();
        }
        if(attackAction != null)
        {
            PlayerAttack();
        }
        
    }
    private Vector3 MovimientoTotal()
    {
        Vector3 camaraForward = camara.transform.forward;
        Vector3 camaraRight = camara.transform.right;
        camaraForward.y = 0f;
        camaraRight.y = 0f;
        camaraForward = camaraForward.normalized;
        camaraRight = camaraRight.normalized;
        Vector3 allMove = (camaraForward * inputMove.y + camaraRight * inputMove.x).normalized;
        return allMove;
    }
    private void PlayerMove()
    {
        Vector3 allMove = MovimientoTotal();
        rb.linearVelocity = new Vector3(allMove.x * speedMove, rb.linearVelocity.y, allMove.z * speedMove);

        if(allMove.sqrMagnitude > 0.001f)
        {
            Quaternion rotacionPlayer = Quaternion.LookRotation(allMove);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotacionPlayer, 10f));
        }
    }
    private void AnimacionMover()
    {
        if(inputMove.magnitude > 0.1f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void PlayerJump()
    {
        if(jumpAction.WasPressedThisFrame() && jumpCurrent > 0f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            animator.SetTrigger("IsJump");
            jumpCurrent--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground"))
        {
            jumpCurrent = jumpMax;
        }
    }
    private void PlayerDash()
    {
        Vector3 allMove = MovimientoTotal();
        if(dashAction.WasPressedThisFrame() && haveDash)
        {
            rb.AddForce(allMove * dashForce, ForceMode.Impulse);
            haveDash = false;
        }
        else if(!haveDash)
        {
            tiempoActualDash -= Time.deltaTime;
            if(tiempoActualDash <= 0f)
            {
                tiempoActualDash = tiempoEsperaDash;
                haveDash = true;
            }
        }
    }
    private void PlayerAttack()
    {
        if(attackAction.WasPressedThisFrame() && haveAttack)
        {
            animator.SetTrigger("IsAttack");
            AudioManager.Instance.PlaySfx(attackSonido);
            haveAttack = false;
        }
        else if(!haveAttack)
        {
            tiempoActualAttack -= Time.deltaTime;
            if(tiempoActualAttack <= 0f)
            {
                tiempoActualAttack = tiempoEsperaAttack;
                haveAttack = true;
            }
        }
    }
}
