using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Car _car;
    // Start is called before the first frame update
    void Start()
    {
        _car = GameObject.FindGameObjectWithTag("Player").GetComponent<Car>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _car.transform.position + new Vector3(0, 0, -10);
    }
}
