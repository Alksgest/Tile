using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float LevelLoadDelay = 3f;
    [SerializeField] private float LevelExitSlowMoFactor = 0.2f;
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("New level is loading.");
        StartCoroutine(LoadNextLevel());
    }
    private IEnumerator LoadNextLevel()
    {

        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex <= SceneManager.sceneCount - 1)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}
