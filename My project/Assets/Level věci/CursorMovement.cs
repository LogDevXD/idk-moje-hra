using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    public float cursorSpeed = 0.1f;

    void Update()
    {
        // Získání pozice kurzoru myši na obrazovce
        Vector2 cursorPosition = Input.mousePosition;

        // Převod pozice kurzoru na pozici v 3D prostoru
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorPosition.x, cursorPosition.y, 0f));

        // Přesun kurzoru na novou pozici v 3D prostoru
        transform.position = Vector3.Lerp(transform.position, worldPosition, cursorSpeed);
    }
}
