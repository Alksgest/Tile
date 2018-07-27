using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;

    [SerializeField] private float LevelLoadDelay = 3f;
    [SerializeField] private float LevelExitSlowMoFactor = 0.2f;
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("New level is loading.");
        //StartCoroutine(WaitFewSeconds());
        StartCoroutine(LoadNextLevel());
    }
    private IEnumerator LoadNextLevel()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            AsyncOperation loadLevel = SceneManager.LoadSceneAsync(currentSceneIndex + 1);
            loadingScreen.SetActive(true);
            while (!loadLevel.isDone)
            {
                float progress = Mathf.Clamp01(loadLevel.progress / 0.9f);
                slider.value = progress;
                Debug.Log(loadLevel.progress);
                yield return null;
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    private IEnumerator WaitFewSeconds()
    {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Time.timeScale = 1f;
    }
}

