using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    void Update()
    {
        //Rotate(x축, y축, z축)으로 받은 회전값 : y축을 기준으로 60도 만큼 회전 (Time.deltaTime 프레임의 주기)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);        
    }
}
