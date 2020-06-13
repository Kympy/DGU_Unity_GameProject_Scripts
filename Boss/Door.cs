using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider door;
    private void Start()
    {
        door = this.GetComponent<BoxCollider>();
        door.enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // 플레이어에게만 열리는 문
        {
            door.enabled = false;
        }
        else door.enabled = true;
    }
}
