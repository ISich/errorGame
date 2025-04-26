using UnityEngine;
using UnityEngine.SceneManagement;  // Нужно для работы с управлением сценами

public class GameController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Senya");
    }

    public void ExitGame()
    {
        // Закрыть приложение
        Application.Quit();
    }
}