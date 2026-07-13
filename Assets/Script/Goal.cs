using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            ScoreManager.Instance.AddScore();
        }
    }
}