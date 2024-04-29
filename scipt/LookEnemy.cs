using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LookEnemy : MonoBehaviour
{

    public Transform enemy;
    public Transform SpPoint;
    
    public Transform viewer;
    RaycastHit hit;
    Vector3 fwd = Vector3.forward;

    [SerializeField]
    public GameObject Bul;
    public int bulspeed = 150;


    public GameObject[] prfabs;

    List<GameObject>[] pool;


    float timer;
    float waitingTime;

    private void Awake()
    {
        //������ �迭�� ���� ��ŭ �ʱ�ȭ 
        pool = new List<GameObject>[prfabs.Length];

        for (int index = 0; index < pool.Length; index++)
        {   //����Ʈ�� ���� �ʱ�ȭ 
            pool[index] = new List<GameObject>();
        }

        Debug.Log(pool.Length);
    }

    private void Start()
    {

        timer = 0.0f;
        waitingTime = 1.5f;

    }

    void Update()
    {
        viewer.LookAt(enemy);

        transform.rotation = viewer.rotation;

        Vector3 newpoint = new Vector3(SpPoint.position.x, viewer.transform.position.y, SpPoint.position .z);

        Debug.DrawRay(newpoint, SpPoint.forward * 10, Color.blue);

        if (Physics.Raycast(newpoint, SpPoint.forward, out hit, 10))
        {
            Debug.Log(hit.collider.gameObject.name);
        }


        //timer += Time.deltaTime;

        //if (timer > waitingTime)
        //{
        //    Bullet();
        //    timer = 0;
        //}
        
    }


    //���� ������Ʈ�� ��ȯ�ϴ� �Լ� ����
    //������ ������ �����ϴ� �Ű����� �߰�
    public GameObject Get(int index)
    {
        GameObject select = null;
        //������ Ǯ�� ��Ȱ��ȭ �� ������Ʈ ����
       

        foreach (GameObject item in pool[index])
        {
            //��Ȱ��ȭ ������Ʈ�� ã���� 
            if (!item.activeSelf)
            { 
                //�߰��ϸ� select ������ �Ҵ�
                select = item;
                //Ȱ��ȭ
                select.SetActive(true);
                break;
            }

        }

        //���� ��ã����(������)
        if (!select)
        {
            //���Ӱ� �����ϰ� select������ �Ҵ�
            select = Instantiate(prfabs[index], transform);
            pool[index].Add(select);
        
        }
        

        return select;

    }




    private void Bullet()
    {
        //����
        GameObject Bullet = Instantiate(Bul, SpPoint.position, SpPoint.rotation);
    
        // Bullet.transform.rotation = Quaternion.Euler(90, 0, 0);

    }




}
