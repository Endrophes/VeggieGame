using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed = 20.0f;
    public Vector3 StartOffSet = Vector3.zero;
    public Vector3 OffSet = Vector3.zero;
    public GameObject target;

    void start()
    {

    }

    void Update()
    {
        transform.RotateAround((target.transform.position), Vector3.up, speed * Time.deltaTime);
    }
}
