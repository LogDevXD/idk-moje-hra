using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthText.SetText("Health: " + currentHealth.ToString());
    }

    void Update()
    {
        // Update player health here...
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthText.SetText("Health: " + currentHealth.ToString());
        if (currentHealth >= 0)
        {
            // Game over logic here...
            SceneManager.LoadScene("youdied");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(10); // or whatever damage value you want
        }
    }
}