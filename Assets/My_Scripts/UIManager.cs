using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private GameObject _winPanel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        int bottleCount = GameObject.FindGameObjectsWithTag("LabItem").Length;

        _counterText.text = "Bottles left: " + bottleCount;

        if (bottleCount == 1)
        {
            _counterText.color = Color.red;
        }

        if (bottleCount <= 0)
        {
            _winPanel.SetActive(true);
            Debug.Log("All targets destroyed!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}