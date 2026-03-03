using System.Collections.Generic;
using UnityEngine;

public class WheelColl : MonoBehaviour
{
    [SerializeField] private List<WheelCollider> _wheelCol;

    public void FixedUpdate()
    {
        foreach (WheelCollider wheelCollider in _wheelCol)
        {
            SetWheelCol(wheelCollider);
        }
    }

    public void SetWheelCol(WheelCollider collider)
    {
        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;

    }
}
