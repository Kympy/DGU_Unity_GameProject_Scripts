using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : MonoBehaviour
{
    public static int sceneIndex;
    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audio.Play();
            SceneManager.LoadScene(1); // 로딩화면 부르기
        }
    }
}