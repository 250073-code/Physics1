using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green * 2f);
        other.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        
    }
}
