using UnityEngine;

public class Forces : MonoBehaviour
{
    private Rigidbody _rb;
    public float forceValue = 10f;
    public float torqueValue = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.AddRelativeForce(0, forceValue, forceValue, ForceMode.Impulse);
        _rb.AddRelativeTorque(torqueValue, 0, 0, ForceMode.Force);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
