using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject body;
    [SerializeField] Color bodyColor;

    private GameObject eye;
    [SerializeField] private Color eyeColor;

    private GameObject leftArm;
    [SerializeField] private Color leftArmColor;
    
    private GameObject rightArm;
    [SerializeField] private Color rightArmColor;

    [SerializeField] private GameObject _bullet;
    private CharacterController _characterController;
    
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject;
        ColorizeBodyPart(body, bodyColor);

        eye = transform.GetChild(0).gameObject;
        ColorizeBodyPart(eye, eyeColor);

        leftArm = transform.GetChild(1).gameObject;
        ColorizeBodyPart(leftArm, leftArmColor);

        rightArm = transform.GetChild(2).gameObject;
        ColorizeBodyPart(rightArm, rightArmColor);
        
        _characterController = gameObject.AddComponent<CharacterController>();
    }

    void ColorizeBodyPart(GameObject go, Color color)
    {
        go.GetComponent<Renderer>().material.color = color;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(-(Input.GetAxis("Horizontal")), 0, -(Input.GetAxis("Vertical")));

        _characterController.Move(move * 5f * Time.deltaTime);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        Shot();
    }

    public void Shot()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(_bullet, leftArm.transform.position, transform.rotation);
        }
    }
    
    
}
