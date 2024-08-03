using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //이동에 사용할 리지바디 컴포넌트
    public float speed = 8f; //이동 속력
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal"); //수평
        float zInput = Input.GetAxis("Vertical"); //수직

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        //자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
