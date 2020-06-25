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
        
        if (index == 0) StartCoroutine(LoadScene(1)); // 메인화면 >> 스타트씬
        if (index == 1) StartCoroutine(LoadScene(3)); // 스타트 >> 에일리언
        if (index == 3) StartCoroutine(LoadScene(4)); // 에일리언 >> 세컨드
        if (index == 4) StartCoroutine(LoadScene(5)); // 세컨드 >> 좀비
        if (index == 5) StartCoroutine(LoadScene(6)); // 좀비 >> 보스
        if (index == 6) StartCoroutine(LoadScene(7)); // 보스 >> 엔딩1
        if (index == 7) StartCoroutine(LoadScene(8)); // 엔딩1 >> 엔딩2

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