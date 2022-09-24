using UnityEngine;
using UnityEngine.Events;

public class PathQuad : MonoBehaviour
{
    #region Fields
    Vector3 scale;

    CanMoveToDoorEvent canMoveToDoorEvent = new CanMoveToDoorEvent();

    float lastInfectedObstacleZ = 0;
    float castlePosZ = 0;

    bool aliveObstacleOnPath = true;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddCanMoveToDoorInvoker(this);
        EventManager.AddChangePathSizeListener(ChangeSize);

        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Invoking event that makes the player ball object moving to the castle
        if((lastInfectedObstacleZ >= castlePosZ - 8) && !aliveObstacleOnPath)
        {
            canMoveToDoorEvent.Invoke(true);
            EventManager.RemoveCanMoveToDoorInvoker(this);
        }
    }

    // Checking the path to collide with obstacle
    void OnCollisionStay(Collision collision)
    {
        aliveObstacleOnPath = false;
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            aliveObstacleOnPath = true;
        }
    }

    /* Checking the path to be triggered by Infected obstacles 
        and castle object to get castle`s position */
    void OnTriggerEnter(Collider trigger)
    {
        if((trigger.gameObject.CompareTag("Obstacle")) ||
            (trigger.gameObject.CompareTag("InfectedObstacle")))
        {
            Destroy(trigger.gameObject);
            if(trigger.gameObject.transform.position.z > lastInfectedObstacleZ)
            {
                lastInfectedObstacleZ = trigger.gameObject.transform.position.z;
            }
        }else if(trigger.gameObject.CompareTag("Castle"))
        {
            castlePosZ = trigger.gameObject.transform.position.z;
        }
        
    }

    // Changing path size
    void ChangeSize(float scalePoint)
    {
        scale.x -= scalePoint;
        gameObject.transform.localScale = scale;
    }
    #endregion

    #region Event methods
    public void AddCanMoveToDoorListener(UnityAction<bool> listener)
    {
        canMoveToDoorEvent.AddListener(listener);
    }
    #endregion
}
