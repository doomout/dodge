using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviverTime;
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        surviverTime = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 아닌 동안
        if (!isGameover)
        {
            //생존 시간 갱신
            surviverTime += Time.deltaTime;
            //생존 시간을 텍스트 컴포넌트에 표시
            timeText.text = "Time: " + (int)surviverTime;
        }
        else
        {
            //게임 오버 상태에서 R키를 누르면
            if (Input.GetKeyDown(KeyCode.R))
            {
                //초기화
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        //현재 상태를 게임 오버 상태로 전환
        isGameover = true;
        //게임 오버 텍스트 게임 오브젝트 활성화
        gameoverText.SetActive(true);

        //BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //이전까지의 최고 기록 보다 현재 생존 시간이 더 크면
        if (surviverTime > bestTime)
        {
            //최고 기록 값 갱신
            bestTime = surviverTime;
            //변경된 최고 기록을 BestTime 키로 저장
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //최고 기록을 표시
        recordText.text = "Best Time: " + (int)bestTime;
    }
}