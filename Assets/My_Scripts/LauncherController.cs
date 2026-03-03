using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private SimulatedPhysics _simulatedPhysics;
    [SerializeField] private AirmailPackage _packagePrefab;

    [Header("Camera Settings")]
    [SerializeField] private Vector3 _camOffset = new Vector3(0.8f, 1.5f, -3.5f);
    [SerializeField] private float _sensitivity = 3f;

    [Header("Rotation Limits")]
    [SerializeField] private float _minVerticalAngle = -15f;
    [SerializeField] private float _maxVerticalAngle = 45f;
    [SerializeField] private float _horizontalLimit = 60f;

    [Header("Launch Settings")]
    [SerializeField] private float _launchForce = 15f;
    [SerializeField] private Vector3 _launchOffset = new Vector3(0, 0.35f, 0.4f);

    private float _currentYaw = 0f;
    private float _currentPitch = 0f;

    void Start()
    {
        _currentYaw = transform.localEulerAngles.y;
        _currentPitch = transform.localEulerAngles.x;
    }

    void Update()
    {
        HandleRotation();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        Vector3 spawnPos = transform.position + transform.TransformDirection(_launchOffset);
        _simulatedPhysics.SimulatedTrajectory(_packagePrefab, spawnPos, transform.forward * _launchForce);
    }

    private void HandleRotation()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * _sensitivity * 20f * Time.deltaTime;
        float verticalInput = Input.GetAxis("Vertical") * _sensitivity * 20f * Time.deltaTime;

        _currentYaw += horizontalInput;
        _currentPitch -= verticalInput;

        _currentPitch = Mathf.Clamp(_currentPitch, _minVerticalAngle, _maxVerticalAngle);
        _currentYaw = Mathf.Clamp(_currentYaw, -_horizontalLimit, _horizontalLimit);

        transform.localRotation = Quaternion.Euler(_currentPitch, _currentYaw, 0);

        if (_cameraTransform != null)
        {
            Quaternion camRotation = Quaternion.Euler(_currentPitch, _currentYaw, 0);
            _cameraTransform.position = transform.position + camRotation * _camOffset;
            _cameraTransform.LookAt(transform.position + transform.forward * 2f);
        }
    }

    private void Shoot()
    {
        Vector3 spawnPos = transform.position + transform.TransformDirection(_launchOffset);
        var spawned = Instantiate(_packagePrefab, spawnPos, transform.rotation);
        
        var rbScript = spawned.GetComponent<AirmailPackage>();
        if (rbScript != null)
        {
            rbScript.Init(transform.forward * _launchForce);
        }
    }
}