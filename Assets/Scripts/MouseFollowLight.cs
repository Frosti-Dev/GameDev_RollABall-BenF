using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseFollowLight : MonoBehaviour
{
    public Camera maincamera;

    public float minRotationY = -90f;
    public float maxRotationY = 90f;

    float ClampAngle(float angle, float min, float max)
    {
        angle = Mathf.Repeat(angle + 180f, 360f) - 180f; 
        return Mathf.Clamp(angle, min, max);
    }

    void Update()
    {
        //rotation y limiter

        Vector3 currentEulerAngles = transform.rotation.eulerAngles;

        
        currentEulerAngles.y = ClampAngle(currentEulerAngles.y, minRotationY, maxRotationY);

        
        transform.rotation = Quaternion.Euler(currentEulerAngles);


        //mouse track
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 normalizedDirection;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = hit.point;
            transform.LookAt(direction);
        }
        else
        {
            transform.LookAt(ray.GetPoint(100f));
        }

    }
}
