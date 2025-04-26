using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;   // Максимальное здоровье
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy hp " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // ���������� �����
    }
}
