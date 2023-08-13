using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private float _steerAngle = 0.1f;
    
    public float _speed = 8f;

    
    public float boostSpeed, slowSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        float steerInput = Input.GetAxis("Horizontal");
        float speedControl = Input.GetAxis("Vertical");
        transform.Translate(0, _speed * Time.deltaTime * speedControl, 0);
        
        if (speedControl >= 0)
        {
            transform.Rotate(0, 0, +-_steerAngle * steerInput*Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, +_steerAngle * steerInput*Time.deltaTime);
        }
        
    }
}
