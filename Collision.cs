using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private bool _hasPackage = false;
    [SerializeField]
    private float _deliveryDelay = 0.5f;
    [SerializeField]
    private Color32 _hasPackageColor;
    [SerializeField]
    private Color32 _hasNoPackageColor;
    [SerializeField]
    private float flashTime = 0.3f;
    private SpriteRenderer spriteRenderer;
    private Car _car;
    [SerializeField]
    private float bumpTime = 4f;
    [SerializeField]
    private float boostTime = 4f;
    private bool alreadyBumped = false;
    private bool alreadyBoosted = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player hit");
        if (!alreadyBumped)
        {
            StartCoroutine(Bump(bumpTime));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Power up collected");
        if (other.tag == "Package" && !_hasPackage)
        {
            _hasPackage = true;
            Debug.Log("Package Collected");
            StartCoroutine(Flash(flashTime));
            //spriteRenderer.color = _hasPackageColor;
            Destroy(other.gameObject, _deliveryDelay);
           //spriteRenderer.color = new Color(0.9843137f, 0.5607843f, 0.2196078f,1);
            //spriteRenderer.color.Equals(_hasPackageColor);
                 
        }
        else if (other.tag == "Delivery")
        {
            if (_hasPackage)
            {
                Debug.Log("Package Delivered");
                _hasPackage = false;
                spriteRenderer.color = _hasNoPackageColor;
            }
            
        }
        else if (other.tag == "Boost")
        {
            if (!alreadyBoosted)
            {
                StartCoroutine(Boost(boostTime));
            }
        }
    }

    IEnumerator Flash(float t)
    {
        while (_hasPackage)
        {
            spriteRenderer.color = _hasPackageColor;
            yield return new WaitForSeconds(t);
            spriteRenderer.color = _hasNoPackageColor;
            yield return new WaitForSeconds(t);
        }
        
        
    }
    IEnumerator Bump(float t)
    {
        alreadyBumped = true;
        //float s = _car._speed;
        _car._speed -= _car.slowSpeed;
        yield return new WaitForSeconds(t);
        _car._speed = 8f;
        alreadyBumped = false;
    }
    IEnumerator Boost(float t)
    {
        alreadyBoosted = true;
        //float s = _car._speed;
        _car._speed = _car.boostSpeed;
        yield return new WaitForSeconds(t);
        _car._speed = 8f;
        alreadyBoosted = false;
    }
}
