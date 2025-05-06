using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // TODO supp SerializeField -> définir _target depuis le code ?
    [SerializeField] private Transform _target;
    Vector3 camOffset;

    void Start()
    {
        camOffset = transform.position - _target.position;    
    }

    void FixedUpdate(){
        transform.position = _target.position + camOffset;
    } 
}
