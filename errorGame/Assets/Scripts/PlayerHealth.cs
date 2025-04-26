using UnityEngine;
using UnityEngine.UI;  // Для работы с UI
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator anim;  // Ссылка на Animator

    public float maxHealth = 100f;
    private float currentHealth;

    public Text timerText;  // Ссылка на UI текст для отображения таймера
    private float timer = 10f;  // Таймер, который отсчитывает 10 секунд

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();  // Получаем компонент Animator

        // Инициализация UI таймера
        if (timerText != null)
        {
            timerText.text = "Time Left: " + timer.ToString("F1");
        }
    }

    void Update()
    {
        // Отсчет таймера
        if (timer > 0)
        {
            timer -= Time.deltaTime;  // Уменьшаем таймер с учетом времени кадра
            if (timerText != null)
            {
                timerText.text = "Time Left: " + timer.ToString("F1");  // Обновляем UI
            }
        }
        else
        {
            Die();  // Если таймер истек, вызываем смерть игрока
        }
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

        // Устанавливаем флаг в Animator, чтобы анимация смерти началась
        anim.SetBool("IsDead", true);
        anim.SetBool("IsExit", true);  // Для выхода из анимации, если есть такая анимация

        // Отключаем движение игрока
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;  // Отключаем атаку

        // Перезагружаем сцену после смерти
        Invoke("ReloadScene", 2f);  // Перезагрузка через 2 секунды
        // Устанавливаем параметр в Animator, чтобы анимация смерти началась
        anim.SetInteger("State", 2);  // Устанавливаем состояние в 2 для Die
    }
    
    public void OnDeathAnimEnd()
    
    {
        Debug.Log("52");
        // Переходим в Exit — Animator покинет state-машину
        anim.SetInteger("State", 0); // останавливает Animator напрочь// не обязателен, но можно
    }

    // Перезагружаем сцену
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Перезагружаем текущую сцену
    }
}
