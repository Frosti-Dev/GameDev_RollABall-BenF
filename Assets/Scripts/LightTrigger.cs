using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light FlashLight;
    public LayerMask ObstacleLayer;

    private void OnTriggerStay(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if (enemy != null )
        {
            Vector3 directionToEnemy = (other.transform.position - transform.position).normalized;
            float distanceToEnemy = Vector3.Distance(transform.position, other.transform.position);

            if (!Physics.Raycast(transform.position, directionToEnemy, distanceToEnemy, ObstacleLayer))
            {
                if (FlashLight.type == LightType.Spot)
                {
                    float angle = Vector3.Angle(transform.forward, directionToEnemy);
                    if (angle <= FlashLight.spotAngle / 2f)
                    {
                        enemy.ApplyLightEffect();
                        Debug.Log("Slow Active");
                    }

                    else
                    {
                        enemy.RemoveLightEffect();
                    }
                }

                else
                {
                    enemy.ApplyLightEffect();
                    Debug.Log("Slow Active");
                }
            }

            else
            {
                enemy.RemoveLightEffect();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.RemoveLightEffect();
        }

    }
}
