using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCamera : MonoBehaviour
{
    #region UI

    [Space]

    public bool isActive = true;

    [Space]

    public bool enableRotation = true;
    public float mouseSensitivity = 1.8f;

    [Space]

    public bool enableTranslation = true;
    public float translationSpeed = 55f;

    [Space]

    public bool enableMovement = true;
    public float movementSpeed = 10f;
    public float boostedSpeed = 50f;
    public KeyCode boostSpeed = KeyCode.LeftShift;
    public KeyCode moveUp = KeyCode.E;
    public KeyCode moveDown = KeyCode.Q;

    [Space]

    public bool enableSpeedAcceleration = true;
    public float speedAccelerationFactor = 1.5f;

    [Space]

    public KeyCode initPositionButton = KeyCode.R;

    #endregion UI

    private CursorLockMode wantedMode;

    private float currentIncrease = 1;
    private float currentIncreaseMem = 0;

    private Vector3 initPosition;
    private Vector3 initRotation;

    private GameObject prometheusObject;

    private void Start()
    {
        prometheusObject = GameObject.Find("Prometheus");

        if (prometheusObject == null)
        {
            Debug.LogError("Prometheus object not found in the scene hierarchy!");
            return;
        }

        transform.position = new Vector3(4.19f, 7f, -13.06f);
        initPosition = transform.position;
        initRotation = transform.eulerAngles;
    }

    private void OnEnable()
    {
        if (isActive)
            wantedMode = CursorLockMode.Locked;
    }

    private void SetCursorState()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = wantedMode = CursorLockMode.None;
        }

        if (Input.GetMouseButtonDown(0))
        {
            wantedMode = CursorLockMode.Locked;
        }

        Cursor.lockState = wantedMode;
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    private void CalculateCurrentIncrease(bool moving)
    {
        currentIncrease = Time.deltaTime;

        if (!enableSpeedAcceleration || enableSpeedAcceleration && !moving)
        {
            currentIncreaseMem = 0;
            return;
        }

        currentIncreaseMem += Time.deltaTime * (speedAccelerationFactor - 1);
        currentIncrease = Time.deltaTime + Mathf.Pow(currentIncreaseMem, 3) * Time.deltaTime;
    }

    private void Update()
    {
        if (carCamSwitch.carCam == true)
        {
            return;
        }

        if (!isActive)
            return;

        SetCursorState();

        if (Cursor.visible)
            return;

        if (enableMovement)
        {
            Vector3 deltaPosition = Vector3.zero;
            float currentSpeed = movementSpeed;

            if (Input.GetKey(boostSpeed))
                currentSpeed = boostedSpeed;

            if (Input.GetKey(KeyCode.W))
                deltaPosition += transform.forward;

            if (Input.GetKey(KeyCode.S))
                deltaPosition -= transform.forward;

            if (Input.GetKey(KeyCode.A))
                deltaPosition -= transform.right;

            if (Input.GetKey(KeyCode.D))
                deltaPosition += transform.right;

            if (Input.GetKey(moveUp))
                deltaPosition += transform.up;

            if (Input.GetKey(moveDown))
                deltaPosition -= transform.up;

            CalculateCurrentIncrease(deltaPosition != Vector3.zero);

            transform.position += deltaPosition * currentSpeed * currentIncrease;
        }

        if (enableRotation)
        {
            transform.rotation *= Quaternion.AngleAxis(
                -Input.GetAxis("Mouse Y") * mouseSensitivity,
                Vector3.right
            );

            transform.rotation = Quaternion.Euler(
                transform.eulerAngles.x,
                transform.eulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivity,
                transform.eulerAngles.z
            );
        }

        if (Input.GetKeyDown(initPositionButton))
        {
            transform.position = initPosition;
            transform.eulerAngles = initRotation;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            MoveCameraAbovePrometheus();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            MoveCameraAbovePrometheus();
        }
    }

    private void MoveCameraAbovePrometheus()
    {
        if (prometheusObject != null)
        {
            Vector3 prometheusPosition = prometheusObject.transform.position;
            float cameraOffset = 10f;

            transform.position = new Vector3(prometheusPosition.x, prometheusPosition.y + cameraOffset, prometheusPosition.z);
        }
    }
}
