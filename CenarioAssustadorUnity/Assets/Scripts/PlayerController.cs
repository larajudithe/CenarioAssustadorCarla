using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController controllerPlayer;
    Vector3 foward;
    Vector3 sides;
    Vector3 vertical;

    float fowardSpeed = 4f;
    float sidesSpeed = 4f;
    // float gravity;
    // float jumpSpeed;
    // float maxJumpHeight = 0.5f;
    // float TimeToMaxHeight = 0.5f;
    public Vector2 moveInput;

    [SerializeField] InputActionAsset inputActions;
    private InputAction moveAction;

    void Awake ()
    {
        moveAction = inputActions.FindAction("Move");
    }

    void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable(); 
        inputActions.FindActionMap("UI").Disable(); 
    }

    void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controllerPlayer = GetComponent<CharacterController>();
        // gravity = (-2 * maxJumpHeight) / (TimeToMaxHeight * TimeToMaxHeight);
        // jumpSpeed = (2 * maxJumpHeight) / TimeToMaxHeight;
    }

    // Update is called once per frame
    void Update()
    {
        //float fowardInput = Input.GetAxisRaw("Vertical");
        moveInput = moveAction.ReadValue<Vector2>();
        float fowardInput = moveInput.y;
        float sidesInput = moveInput.x;

        foward = fowardInput * fowardSpeed * transform.forward;
        sides = sidesInput * sidesSpeed *transform.right;

        // vertical += gravity * Time.deltaTime * Vector3.up;

         if (controllerPlayer.isGrounded)
        {
            vertical =  Vector3.down;
        }

        // if (Input.GetKeyDown(KeyCode.Space) &&  controllerPlayer.isGrounded)
        // {
        //     vertical = jumpSpeed * Vector3.up;
        // }

        if (vertical.y > 0 && (controllerPlayer.collisionFlags & CollisionFlags.Above) !=0)
        {
                vertical = Vector3.zero;
        }


        Vector3 finalVelocity = foward + sides + vertical;
        controllerPlayer.Move(finalVelocity * Time.deltaTime);
    }
}
