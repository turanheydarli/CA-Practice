using System.Collections;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void Start()
    {
        if (transform.name != "Bullet")
        {
            WaitAndDestroy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 6f * Time.deltaTime;
    }
    
    void WaitAndDestroy()
    {
        Destroy(gameObject,5f);
    }

}
