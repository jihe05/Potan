using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class POtan : MonoBehaviour
{

    private int speed = 150;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }


}
