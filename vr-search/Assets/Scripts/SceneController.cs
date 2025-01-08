using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int levelToSwitch;
    private int currentBuildIndex;
    private void Awake()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        levelToSwitch = currentBuildIndex;
    }
    public void StartNextLevel()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);
    }
    public void StartPreviousLevel()
    {
        SceneManager.LoadScene(currentBuildIndex - 1);
    }
    public void StartLevel()
    {
        SceneManager.LoadScene(levelToSwitch);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentBuildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
