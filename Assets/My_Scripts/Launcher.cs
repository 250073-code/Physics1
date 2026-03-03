 using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private SimulatedPhysics _simulatedPhysics;
    [SerializeField] private AirmailPackage _airmailPackagePrefab;
    [SerializeField] private float launchForce = 10f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] Vector3 _linePositionOffset = new Vector3(0, 0.35f, -0.5f);

    void FixedUpdate()
    {
        Vector3 spawnPos = transform.position + transform.TransformDirection(_linePositionOffset);
        _simulatedPhysics.SimulatedTrajectory(_airmailPackagePrefab, spawnPos, transform.forward * launchForce);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var spawned = Instantiate(_airmailPackagePrefab, spawnPos, transform.rotation);
            //spawned.transform.parent = gameObject.transform.root;

            spawned.Init(transform.forward * launchForce);
        }
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, -_rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right, _rotationSpeed * Time.deltaTime);
        }
    }
}
