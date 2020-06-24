using UnityEngine;
using System.Collections;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monster;
    public float createTime; // x초마다 몬스터 생성
    public int maxMonsterCount = 30; // 맵에 생성되는 최대 몬스터 수
    public static int currentMonsterCount = 0;

    public Transform[] spawnPoints;

    void Start()
    {
        // spawnpoints를 게임시작과 함께 배열에 담기
        spawnPoints = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        createTime = 0.2f;
        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (currentMonsterCount < maxMonsterCount)
        {
            int index = Random.Range(1, spawnPoints.Length);
            Instantiate(monster, spawnPoints[index].position, Quaternion.identity);
            currentMonsterCount += 1;
            //Debug.Log(currentMonsterCount);

            yield return new WaitForSeconds(createTime);
            if(currentMonsterCount == maxMonsterCount)
            {
                createTime = 5f; // 초기 전체생성 끝나면 생성 쿨타임 5초 설정
            }
        }
    }

}