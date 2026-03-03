using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AirmailPackage : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public void Init(Vector3 velocity)
    {
        rb.AddForce(velocity, ForceMode.Impulse);

    }
}
