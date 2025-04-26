using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1f;      // Радиус атаки
    public float damage = 10f;          // Урон при атаке
    public Transform attackPoint;       // Точка удара
    public LayerMask enemyLayers;       // Слой врагов

    void Update()
    {
        // Если игрок нажал клавишу для атаки (например, пробел)
        if (Input.GetKeyDown(KeyCode.Space))  // Можно заменить на любую клавишу
        {
            Attack();
        }
    }

    void Attack()
    {
        // Показываем область удара с использованием OverlapCircle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Проходим по всем врагам в области удара
        foreach (var enemy in hitEnemies)
        {
            // Наносим урон врагу
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(damage);  // Враг получает урон
        }

        // Для отладки можно добавить визуализацию области удара
        Debug.DrawLine(attackPoint.position, new Vector2(attackPoint.position.x + attackRange, attackPoint.position.y), Color.red, 0.1f);
    }
}