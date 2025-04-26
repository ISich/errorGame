using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;  // Ссылка на Animator

    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();  // Получаем компонент Animator
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();  // Если здоровье стало меньше 0, вызываем смерть
        }
    }

    // Метод для смерти персонажа
    void Die()
    {
        Debug.Log("Персонаж умер!");

        // Устанавливаем Trigger для анимации смерти
        anim.SetTrigger("Die");

        // Дополнительно можно отключить управление персонажем после смерти
        // Например, отключаем движение:
        this.enabled = false;
    }
}