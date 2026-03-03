using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityScale = -1f;
    [SerializeField] private ConstantForce _constantForce;

    void Start()
    {
        Physics.gravity = new Vector3(0, gravityScale, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _constantForce.force = new Vector3(0f, 9.83f, 0f);
        }
    }
}
