using UnityEngine;

public class ReturnToStartPosition : MonoBehaviour
{
    public Vector2 startingPosition; // počáteční pozice objektu

    private void Start()
    {
        startingPosition = transform.position; // uložení počáteční pozice objektu
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Vrátit objekt na startovní pozici
            transform.position = startingPosition;
        }
    }
}

