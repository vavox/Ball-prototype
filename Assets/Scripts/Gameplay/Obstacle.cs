using UnityEngine;

public class Obstacle : MonoBehaviour
{
    #region Fields
    float infectionRadius;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddSetAreaListener(ChangeInfectionRadius);
    }

    void OnCollisionEnter(Collision collision)
    {
        /* Setting new tag, material and collider radius to obstacle object
            and setting "infected" obstacle object as trigger
            when obstacle object collides with shooting ball object.
            Destroying shotting ball object */
        if(collision.gameObject.CompareTag("ShootingBall"))
        {
            gameObject.tag = "InfectedObstacle";
            ChangeColliderRadius(infectionRadius);
            ChangeObstacleMaterial();
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(collision.gameObject);
        }   
    }

    void OnTriggerEnter(Collider trigger)
    {
        /* Setting new material to obstacle object in "infection area" (Infected Obstacle
            collider radius) when obstacle get triggered by infected obstacle object.
            setting infected object as trigger */
        if(trigger.gameObject.CompareTag("InfectedObstacle"))
        {
            ChangeObstacleMaterial();
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }
    #endregion

    #region Private methods
    void ChangeColliderRadius(float radius)
    {
        gameObject.GetComponent<CapsuleCollider>().radius = infectionRadius;
    }

    void ChangeObstacleMaterial()
    {
        gameObject.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/Ball");
    }

    void ChangeInfectionRadius(float radius)
    {
        infectionRadius = radius;
    }
    #endregion
}
