using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;           // Скорость движения
    public float damage = 10f;         // Урон, который наносит враг (для получения урона от игрока)
    public float attackRange = 1f;     // Радиус атаки
    public float attackCooldown = 1f;  // Время между атаками

    private Transform player;          // Ссылка на игрока
    private float lastAttackTime;      // Время последней атаки

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;  // Находим игрока по тегу
    }

    void Update()
    {
        if (player == null) return;

        // Двигаем врага к игроку
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Проверка на радиус атаки (если враг в радиусе атаки, то наносится урон)
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackRange && Time.time > lastAttackTime + attackCooldown)
        { // Наносим урон игроку
            lastAttackTime = Time.time;  // Обновляем время последней атаки
        }
    }
}