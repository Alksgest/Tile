using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenePersist : MonoBehaviour
{

    private int startingSceneIndex;
    private int currentSceneIndex;
    private void Awake()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Awake! Starting scene index: " + startingSceneIndex);
        var previousPresists = FindObjectsOfType<ScenePersist>();
        if (previousPresists.Length > 1)
        {
            Debug.Log("Awake! Object on scene: " + SceneManager.GetActiveScene().buildIndex.ToString() + " is destroing");
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {

        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Start! Starting scene index: " + startingSceneIndex);
    }
    private void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Update! Current scene: " + startingSceneIndex + "\nStarting scene index: " + startingSceneIndex.ToString());
        if (currentSceneIndex != startingSceneIndex)
        {
            Debug.Log("Update! Object on scene: " + currentSceneIndex.ToString() + " is destroing");
            Destroy(gameObject);
        }

    }
}
