using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : MonoBehaviour
{
    public static int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(1); // 로딩화면 부르기
        }
    }
}