using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public float kickForce = 500f;

    private bool playerNear = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            rb.AddForce(Vector3.forward * kickForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}