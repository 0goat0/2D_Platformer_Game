using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;

    private void LateUpdate()
    {
        Vector3 targetPos=target.position;
        transform.position=new Vector3(targetPos.x,targetPos.y,transform.position.z);
    }
}
