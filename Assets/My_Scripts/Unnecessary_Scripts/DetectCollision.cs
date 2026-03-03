using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public float radius = 10f;
    public float power = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.tag == "Hazard")
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Debug.Log("Collision detected with Hazard!");
            // You can add additional logic here, such as applying damage or triggering an event.

            Vector3 explosivePos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosivePos,  radius);
            foreach (Collider collider in colliders)
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosivePos, radius, 3.0f, ForceMode.Impulse);
                }
            }

            Destroy(gameObject); // Destroy the explosive object after the collision
        }
    }
}
