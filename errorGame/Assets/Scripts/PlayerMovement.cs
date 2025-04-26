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
        anim = GetComponent<Animator>(); // Получаем компонент Animator
    }

    void Update()
    {
        // Получаем ввод с клавиатуры
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); // Нормализуем, чтобы скорость была одинаковой во всех направлениях

        // Передаем параметр IsMoving в Animator (для переключения анимаций)
        bool isMoving = moveInput.sqrMagnitude > 0.01f;  // Проверяем, движется ли персонаж
        anim.SetBool("IsMoving", isMoving);  // Устанавливаем параметр в Animator
    }

    void FixedUpdate()
    {
        // Двигаем персонажа с физикой
        rb.velocity = moveInput * moveSpeed;
    }
}