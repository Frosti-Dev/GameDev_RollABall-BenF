using UnityEngine;

public class MouseFollowLight : MonoBehaviour
{
    public Camera maincamera;

    void Update()
    {
       Cursor.visible = false;
        //mouse track
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            Vector3 direction = hit.point;

            Vector3 newDirection = new Vector3(direction.x, 0, direction.z);
            transform.LookAt(newDirection);
        }
        else
        {
            transform.LookAt(ray.GetPoint(100f));
        }

    }
}
