using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingScreen : MonoBehaviour
{
    public Slider slider;
    public Text progressText;

    private void Start() {
        LoadingScreenLoader(2);
    }
    public void LoadingScreenLoader(int sceneIndex){
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            progressText.text = Mathf.RoundToInt(progress * 100f)+"%";
            //progressText.text = progress*100f+"%";
            yield return null;
        }
    }
}
