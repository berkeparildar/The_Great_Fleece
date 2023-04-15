using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync("Main");
        while (!op.isDone)
        {
            progressBar.fillAmount = op.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
