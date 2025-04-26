using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    public float attackRange = 5f; // ��������� �����
    public float attackDamage = 10f; // ���� ��� �����

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        if (Input.GetMouseButtonDown(0)) // ����� ������ ����
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
        // �������� ������� ���� � ������� �����������
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - (Vector2)transform.position;

        // ���� ��� ������ � ������� �����
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                // ���������, ��������� �� ���� � ������ ����� �� ������ �� �������
                Vector2 enemyPos = enemy.transform.position;
                Vector2 directionToEnemy = enemyPos - (Vector2)transform.position;
                float angle = Vector2.Angle(direction, directionToEnemy);

                // ���� ���� ��������� � �������� ���� �����
                if (angle < 45f) // ����� ��������� ����, ����� ��������� ������ ������ � �������� ������ �����
                {
                    enemy.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
                }
            }
        }
    }
}
