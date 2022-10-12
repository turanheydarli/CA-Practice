using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,20)]
    [SerializeField]
    private float speed = 5f;
    private float horizontal;
    private bool isRight;
    
    [SerializeField] private GameObject bullet;

    private Transform gunTransform;
    // Start is called before the first frame update
    void Start()
    {
        gunTransform = transform.GetChild(1).transform;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        
        transform.position += new Vector3(horizontal * speed, 0, 0) * Time.deltaTime;

        if (horizontal < 0 && !isRight)
        {
            Flip();
        }
        else if( horizontal > 0 && isRight)
        {
            Flip();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        Instantiate(bullet,  gunTransform.position, transform.rotation);
    }

    private void Flip()
    {
            transform.Rotate(0f, 180f, 0f);
            isRight = !isRight;
    }
}
