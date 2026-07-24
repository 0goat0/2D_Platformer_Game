using UnityEngine;

public class MinCamar : MonoBehaviour
{
    [SerializeField] Transform target;

    private void LateUpdate()
    {
        Vector3 targetPos = target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
