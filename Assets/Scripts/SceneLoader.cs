using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public TextMeshProUGUI percentLoaded;
    public Slider progressBar;

    AsyncOperation loadingOperation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeLoadingScreen(2));
        loadingOperation = SceneManager.LoadSceneAsync(LocalData.sceneToLoad);
    }

    // Update is called once per frame
    void Update()
    {
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        progressBar.value = progressValue;
        percentLoaded.text = Mathf.Round(progressValue * 100) + "%";

    }

    IEnumerator FadeLoadingScreen(float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }//end of FadeLoadingScreen
}
