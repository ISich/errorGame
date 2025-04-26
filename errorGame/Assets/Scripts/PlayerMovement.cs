using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator anim; // Ссылка на Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("State", 0); // Устанавливаем начальное состояние (Idle)
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // Нормализуем, чтобы скорость была одинаковой во всех направлениях
        if (anim.GetInteger("State") != 2)
        {
            // Проверяем, движется ли персонаж
            if (moveInput.sqrMagnitude > 0.01f) // Персонаж двигается
            {
                anim.SetInteger("State", 1); // Устанавливаем состояние в 1 для Walking
            }
            else // Персонаж не двигается
            {
                anim.SetInteger("State", 0); // Устанавливаем состояние в 0 для Idle
            }
        }
    }

    void FixedUpdate()
    {
        // Двигаем персонажа с физикой
        rb.velocity = moveInput * moveSpeed;
    }
}