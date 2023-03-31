using UnityEngine;

public class Skok : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Získat vstupy z klávesnice pro pohyb hráče
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Vytvořit vektor pohybu
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        // Pohybovat hráče v daném směru
        rb.AddForce(movement * moveSpeed);

        // Detekovat, zda je hráč na zemi
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Pokud je hráč na zemi a hráč stiskl mezerník, hráč může skočit
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
