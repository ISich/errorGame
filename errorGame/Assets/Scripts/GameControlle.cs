using UnityEngine;
using UnityEngine.SceneManagement;  // ����� ��� ������ � ����������� �������

public class GameController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void ExitGame()
    {
        // ������� ����������
        Application.Quit();
    }
}