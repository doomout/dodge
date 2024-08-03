using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody; //이동에 사용할 리지바디 컴포넌트
    public float speed = 8f; //이동 속력
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            //위쪽 방향키 입력 감지된 경우 z방향으로 힘주기
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //위쪽 방향키 입력 감지된 경우 -z방향으로 힘주기
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //위쪽 방향키 입력 감지된 경우 x방향으로 힘주기
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            //위쪽 방향키 입력 감지된 경우 -x방향으로 힘주기
            playerRigidbody.AddForce(-speed, 0f, 0f );
        }
    }

    public void Die()
    {
        //자신의 게임 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
