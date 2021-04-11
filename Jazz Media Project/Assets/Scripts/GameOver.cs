using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public float timeLimit;
    float timer;
    public LevelLoader loader;

    private void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeLimit)
        {
            timer += Time.deltaTime;
        }
        else
        {
            loader.loadMainMenuScene();
        }
    }

    public void loadMainMenuListen()
    {
        StartCoroutine(loadMainMenu());
    }

    IEnumerator loadMainMenu()
    {
        loader.loadMainMenuScene();
        yield return null;
    }
}
