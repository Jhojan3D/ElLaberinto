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
    [Header("Setting Move")]
    [SerializeField] private float speedMove;
    private Vector2 inputMove;
    [Header("Setting Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int jumpMax;
    [SerializeField] private int jumpCurrent;



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
    }
    private void Start()
    {
        jumpCurrent = jumpMax;
    }
    private void Update()
    {
        if(moveAction != null)
        {
            inputMove = moveAction.ReadValue<Vector2>();
            PlayerMove();
        }
        if(jumpAction != null)
        {
            PlayerJump();
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

    private void PlayerJump()
    {
        if(jumpAction.WasPressedThisFrame())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }
}
