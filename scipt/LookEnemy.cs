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
        //프리팹 배열의 길이 만큼 초기화 
        pool = new List<GameObject>[prfabs.Length];

        for (int index = 0; index < pool.Length; index++)
        {   //리스트들 각각 초기화 
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


    //게임 오브젝트를 반환하는 함수 선언
    //가져올 종류를 결정하는 매개변수 추가
    public GameObject Get(int index)
    {
        GameObject select = null;
        //선택한 풀의 비활성화 된 오브젝트 접근
       

        foreach (GameObject item in pool[index])
        {
            //비활성화 오브젝트를 찾으면 
            if (!item.activeSelf)
            { 
                //발견하면 select 변수의 할당
                select = item;
                //활성화
                select.SetActive(true);
                break;
            }

        }

        //만약 못찾으면(없으면)
        if (!select)
        {
            //새롭게 생성하고 select변수의 할당
            select = Instantiate(prfabs[index], transform);
            pool[index].Add(select);
        
        }
        

        return select;

    }




    private void Bullet()
    {
        //발포
        GameObject Bullet = Instantiate(Bul, SpPoint.position, SpPoint.rotation);
    
        // Bullet.transform.rotation = Quaternion.Euler(90, 0, 0);

    }




}
