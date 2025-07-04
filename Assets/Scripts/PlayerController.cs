using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; //이동 속력

    // Start is called before the first frame update
    void Start()
    {
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 지정
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0f, zSpeed)로 설정
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //리지드바디의 속도를 newVelocity로 설정
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false); //플레이어 오브젝트를 비활성화

        //씬에 존재하는 GameManager 스크립트를 찾아 EndGame() 메서드 호출
        GameManager gameManager = FindObjectOfType<GameManager>();
        //가져온 GameManager 스크립트의 EndGame() 메서드 호출
        gameManager.EndGame();
    }

}
