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

    // Метод получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("Игрок получил урон! Текущее здоровье: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Если здоровье стало меньше 0, вызываем смерть
        }
    }

    // Метод для смерти персонажа
    void Die()
    {
        Debug.Log("Игрок умер!");

        // Устанавливаем флаг в Animator, чтобы анимация смерти началась
        anim.SetBool("IsDead", true);
        anim.SetBool("IsExit", true);
        // Дополнительно можно отключить управление персонажем после смерти
        // Например, отключаем движение:
    }
}