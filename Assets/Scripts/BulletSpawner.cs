using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        //최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        //탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤 값 지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아서 target에 저장
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if (timeAfterSpawn >= spawnRate)
        {
            //최근 생성 이후의 누적 시간을 0으로 초기화
            timeAfterSpawn = 0f;
            
            GameObject bullet 
                = Instantiate(bulletPrefab, transform.position, transform.rotation); // 탄알 생성
            
            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            // 다음 탄알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤 값 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
