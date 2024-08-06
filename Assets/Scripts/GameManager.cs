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
        //���� ������ �ƴ� ����
        if (!isGameover)
        {
            //���� �ð� ����
            surviverTime += Time.deltaTime;
            //���� �ð��� �ؽ�Ʈ ������Ʈ�� ǥ��
            timeText.text = "Time: " + (int)surviverTime;
        }
        else
        {
            //���� ���� ���¿��� RŰ�� ������
            if (Input.GetKeyDown(KeyCode.R))
            {
                //�ʱ�ȭ
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        //���� ���¸� ���� ���� ���·� ��ȯ
        isGameover = true;
        //���� ���� �ؽ�Ʈ ���� ������Ʈ Ȱ��ȭ
        gameoverText.SetActive(true);

        //BestTime Ű�� ����� ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ� ��� ���� ���� ���� �ð��� �� ũ��
        if (surviverTime > bestTime)
        {
            //�ְ� ��� �� ����
            bestTime = surviverTime;
            //����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        //�ְ� ����� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}