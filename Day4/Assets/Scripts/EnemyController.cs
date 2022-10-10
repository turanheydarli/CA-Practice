using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject body;
    
    [SerializeField] 
    Color bodyColor;

    private GameObject eye;
    
    [SerializeField] 
    private Color eyeColor;

    private GameObject leftArm;
    
    [SerializeField] 
    private Color leftArmColor;
    
    private GameObject rightArm;
    [SerializeField]
    private Color rightArmColor;

    [SerializeField] 
    private GameObject _player;
    
    [SerializeField] private GameObject _bullet;

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
        
    }

    void ColorizeBodyPart(GameObject go, Color color)
    {
        go.GetComponent<Renderer>().material.color = color;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform.position);

        if (Vector3.Distance(_player.transform.position, transform.position) <= 7)
        {
            return;
        }

        transform.position += transform.forward * 4f * Time.deltaTime;
    }
    
    public void Shot()
    { 
        Instantiate(_bullet, leftArm.transform.position, transform.rotation);
    }
}
