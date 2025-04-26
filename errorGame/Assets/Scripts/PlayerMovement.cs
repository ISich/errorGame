using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float attackRange = 5f; // Дистанция атаки
    public float attackDamage = 10f; // Урон при атаке

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            Attack();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    void Attack()
    {
        // Получаем позицию мыши в мировых координатах
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;

        // Ищем все врагов в области атаки
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // Проверяем, находится ли враг в прямой линии от игрока до курсора
                Vector2 enemyPos = enemy.transform.position;
                Vector2 directionToEnemy = enemyPos - (Vector2)transform.position;
                float angle = Vector2.Angle(direction, directionToEnemy);

                // Если враг находится в пределах угла атаки
                if (angle < 45f) // Можно настроить угол, чтобы атаковать только врагов в пределах прямой линии
                {
                    enemy.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
                }
            }
        }
    }
}
