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
        if (currentHealth <= 0)
        {
            Die();  // Если здоровье стало меньше 0, вызываем смерть
        }
        else
        {
            currentHealth -= damage;
            Debug.Log("Игрок получил урон! Текущее здоровье: " + currentHealth);
        }
    }

    // Метод для смерти персонажа
    void Die()
    {
        Debug.Log("Игрок умер!");

        // Устанавливаем параметр в Animator, чтобы анимация смерти началась
        anim.SetInteger("State", 2);  // Устанавливаем состояние в 2 для Die
    }
    
    public void OnDeathAnimEnd()
    
    {
        Debug.Log("52");
        // Переходим в Exit — Animator покинет state-машину
        anim.SetInteger("State", 0); // останавливает Animator напрочь// не обязателен, но можно
    }
}