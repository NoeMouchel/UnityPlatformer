using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton: MonoBehaviour
{
    public void PlayLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
