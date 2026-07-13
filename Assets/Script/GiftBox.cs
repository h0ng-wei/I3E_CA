using UnityEngine;
using UnityEngine.InputSystem;

public class GiftBox : MonoBehaviour
{
    private bool playerNear = false;
    private int pressCount = 0;

    void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            pressCount++;

            Debug.Log("Pressed E: " + pressCount);

            if (pressCount >= 3)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            Debug.Log("Player entered.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;
            Debug.Log("Player left.");
        }
    }
}