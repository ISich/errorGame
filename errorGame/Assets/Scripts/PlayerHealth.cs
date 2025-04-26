using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;    // Максимальное здоровье
    private float currentHealth;      // Текущее здоровье

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Функция получения урона
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;  // Уменьшаем здоровье

        Debug.Log("Player took damage! HP = " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Если здоровье = 0, вызываем функцию смерти
        }
    }

    void Die()
    {
        Debug.Log("Player died!");

        // Добавь логику, что происходит, когда игрок умирает
        // Например, перезагрузка сцены, остановка игры или вывод экрана смерти
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}