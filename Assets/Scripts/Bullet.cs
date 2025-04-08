using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드 바디


    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>(); // 리지드 바디 컴포넌트 가져오기
        bulletRigidbody.velocity = transform.forward * speed; // 탄알의 속력 설정

        Destroy(gameObject, 3f); // 3초 후에 탄알 삭제    
    }

    void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가지고 있을 때
        if (other.tag == "Player")
        {
             // PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
             playerController.Die();
            } 
        }
    }
}
