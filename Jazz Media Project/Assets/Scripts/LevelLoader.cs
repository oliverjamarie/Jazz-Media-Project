using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Slider progress;
    public float timeMutli = 1.0f;
     

    public void loadScene()
    {
        if (progress != null)
        {
            progress.minValue = 0f;
            progress.value = 0;
            StartCoroutine(loadAsync(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void loadScene(int levelIndex)
    {

        if (progress != null)
        {
            progress.minValue = 0f;
            progress.value = 0;
            StartCoroutine(loadAsync(levelIndex));
        }
        else
        {
            SceneManager.LoadSceneAsync(levelIndex);
        }
        
    }

    public void loadGameOverScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings);

    }

    public void loadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    

    IEnumerator loadAsync(int levelIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelIndex);
        
        while (op.isDone == false)
        {
            if (progress.value >= progress.maxValue)
            {
                progress.value = progress.minValue;
            }
            else
            {
                progress.value += Time.deltaTime * timeMutli;
            }
            yield return null;
        }
    }

}
