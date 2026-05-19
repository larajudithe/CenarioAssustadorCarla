using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFirstPerson : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 0.05f;
    float sensitivityY = 0.05f;
    float rotationX = 0;
    float rotationY = 0;
    float angleYmin = -90;
    float angleYmax = 90;
    float smoothRotX = 0f;
    float smoothRotY = 0f;
    float smoothCoefX = 0.0002f;
    float smoothCoefY= 0.0002f;

    [SerializeField] InputActionAsset inputActions;
    private InputAction lookAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        lookAction = inputActions.FindAction("Look");
    }
    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;

    }
    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }
    // Update is called once per frame
    void Update()
    {

        Vector2 lookInput = lookAction.ReadValue<Vector2>();
        float verticalDelta = lookInput.y;
        float horizontallDelta = lookInput.x;

        smoothRotX = Mathf.Lerp(smoothRotX, horizontallDelta, smoothCoefX);
        smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefY);

        rotationX += smoothRotX;
        rotationY += smoothRotY;

        rotationX += horizontallDelta;
        rotationY += verticalDelta;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3 (0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
