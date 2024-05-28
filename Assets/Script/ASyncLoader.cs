using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASyncLoader : MonoBehaviour {
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public Slider loadingSlider;

    public void LoadLevelBtn(string levelToLoad) {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad) {
        float loadingDuration = 3f; // thời gian loading 3 giây
        float elapsedTime = 0f;

        // bắt đầu load scene không cho nó active ngay lập tức
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        loadOperation.allowSceneActivation = false;

        while (elapsedTime < loadingDuration) {
            elapsedTime += Time.deltaTime;
            loadingSlider.value = Mathf.Clamp01(elapsedTime / loadingDuration);
            yield return null;
        }

        // Sau 3 giây, chuyển sang scene mới
        loadOperation.allowSceneActivation = true;
    }
}
