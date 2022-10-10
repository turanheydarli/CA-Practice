using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 distance;
    
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - _player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraFollow();
    }

    public void CameraFollow()
    {
        Vector3 targetPos = _player.transform.position + distance;
        Vector3 smoothFollow = Vector3.Slerp(transform.position, targetPos, 5f);
        transform.position = smoothFollow;
        transform.LookAt(_player.transform.position);
    }
}
