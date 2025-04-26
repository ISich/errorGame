using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;   // Максимальное здоровье
    private float currentHealth;     // Текущее здоровье

    void Start()
    {
        currentHealth = maxHealth;   // Устанавливаем текущее здоровье равным максимальному
    }

    // Функция получения урона
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;  // Уменьшаем здоровье врага на величину урона
        Debug.Log("Enemy took damage! HP = " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Если здоровье стало 0 или меньше, враг умирает
        }
    }

    // Функция смерти врага
    void Die()
    {
        Debug.Log("Enemy died!");
        // Здесь можно добавить анимацию смерти, звуки или другие эффекты
        Destroy(gameObject);  // Уничтожаем врага
    }
}