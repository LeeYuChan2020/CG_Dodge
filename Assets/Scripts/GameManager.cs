using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement;
using TMPro; // 씬 관리 관련 라이브러리


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트

    //1. Text 사용시
    /*
    public Text TimeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 텍스트 컴포넌트
*/
    //2. TMP 사용시
    public TMP_Text TimeText;
    public TMP_Text recordText;

    private float survivalTime; // 생존 시간
    private bool isGameover; // 게임 오버상태

    // Start is called before the first frame update
    void Start()
    {
        //생존 시간과 게임오버 상태 초기화
        survivalTime = 0f;
        isGameover = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            //생존시간 갱신
            survivalTime += Time.deltaTime;
            //갱신할 생존 시간을 tiemText 컴포넌트를 이용해서 표시
            TimeText.text = "Time: " + (int)survivalTime;
        }
        else
        {
            // 게임오버 상태에서 R 키를 누른경우
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Dodge 씬 재시작
                SceneManager.LoadScene("Dodge");
            }
        }
    }

    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;
        //게임오버텍스트 게임 오브젝트 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        // 이전까지의 최고기록보다 현재 생존시간이 더크다면
        if (survivalTime > bestTime)
        {
            //최고기록값을 현재 생존 기간 값으로 변경
            bestTime = survivalTime;
            //변경된 최고기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //최고기록을 recordText 텍스트 컴포넌트에 표시
        recordText.text = "Best Time: " + (int)bestTime;

    }
}
