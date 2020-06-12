using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    public float createTime = 3f; // 4초마다 몬스터 생성
    public int maxMonsterCount = 30; // 맵에 생성되는 최대 몬스터 수
    public int currentMonsterCount = 1;

    public Transform[] spawnPoints;

    void Start()
    {
        // spawnpoints를 게임시작과 함께 배열에 담기
        spawnPoints = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (currentMonsterCount < 40)
        {
            int index = Random.Range(1, spawnPoints.Length);
            Instantiate(monster, spawnPoints[index].position, Quaternion.identity);
            currentMonsterCount += 1;

            yield return new WaitForSeconds(createTime);
        }
    }

}