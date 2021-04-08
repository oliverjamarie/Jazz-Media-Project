using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Slider progress;

    public void loadScene()
    {
        StartCoroutine(loadAsync());
        progress.value = 0;
    }

    IEnumerator loadAsync()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("KitsuneBattle");

        while (op.isDone == false)
        {
            progress.value = op.progress;
            yield return null;
        }
    }

}
