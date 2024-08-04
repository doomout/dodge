using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //������ Ÿ���� ��ʺ� ������
    public float spawnRateMin = 0.5f; //�ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        //ź�� ���� ������ ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ� ���� ũ�ų� ���ٸ�.
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����.
            timeAfterSpawn = 0f;
            //bulletPrefab�� �������� position ��ġ�� , rotation ȸ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ�� 
            bullet.transform.LookAt(target);

            //������ ���� ������ ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
