using UnityEngine;

public class PlayerExplosion : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>(); // Получаем компонент Animator
    }

    // Эта функция вызывается по завершению анимации взрыва
    public void OnExplosionEnd()
    {
        // Устанавливаем параметр в true, чтобы переключиться на следующее состояние
        anim.SetBool("IsExit", true);  // Параметр "exploded" должен быть в Animator
    }
}