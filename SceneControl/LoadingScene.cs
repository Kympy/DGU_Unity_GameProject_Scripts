using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Image progressBar;
    private int index;
    private void Start()
    {
        index = PortalEnter.sceneIndex;
        Debug.Log(index);
        if (index == 0) StartCoroutine(LoadScene(2)); // 스타트씬 >> 에일리언
        else if (index == 2) StartCoroutine(LoadScene(3)); // 에일리언 >> 세컨드씬
        else if (index == 3) StartCoroutine(LoadScene(4)); // 세컨드씬 >> 좀비
        else if (index == 4) StartCoroutine(LoadScene(5)); // 좀비 >> 보스씬
    }
    IEnumerator LoadScene(int num)
    {
        yield return null;
        AsyncOperation oper = SceneManager.LoadSceneAsync(num);

        
        //LoadSceneAsync ("게임씬이름 or Index")
        oper.allowSceneActivation = false;
        //allowSceneActivation 이 true가 되는 순간이 바로 다음 씬으로 넘어가는 시점

        float timer = 0.0f;
        float delayTime = 3f;
        while (!oper.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            
            if (oper.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1.0f, timer);

                if (progressBar.fillAmount == 1.0f && timer > delayTime)
                {
                    oper.allowSceneActivation = true;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, oper.progress, timer);
                if (progressBar.fillAmount >= oper.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}