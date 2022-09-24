using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    #region Fields
    AddForceEvent addForceEvent = new AddForceEvent();
    ChangeScaleEvent changeScaleEvent = new ChangeScaleEvent();
    ChangePathSizeEvent changePathSizeEvent = new ChangePathSizeEvent();
    GameLostEvent gameLostEvent = new GameLostEvent();
    GameWonEvent gameWonEvent = new GameWonEvent();

    Vector3 scale;
    
    const float ScalePoint = 0.02f;
    float colliderRadius;
    float defaultScale;

    bool canShoot = true;
    bool gameLost = false;
    bool canMoveToDoorState = false;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddAddForceInvoker(this);
        EventManager.AddChangeScaleInvoker(this);
        EventManager.AddChangePathSizeInvoker(this);
        EventManager.AddGameLostInvoker(this);
        EventManager.AddGameWonInvoker(this);
        EventManager.AddCanShootListener(ChangeShootingState);
        EventManager.AddCanMoveToDoorListener(ChangeMoveToDoorState);

        colliderRadius = gameObject.GetComponent<SphereCollider>().radius;
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = scale; 
        if(scale.x < 0.5) 
        { 
            gameLost = true;
            gameLostEvent.Invoke(true);
        }
        
        if(canMoveToDoorState) { MoveToDoor(); }
    }

    /* Decrease PlayerBall object`s scale; Increase ShootingBall object`s scale  
        when touching the PlayerBall object*/
    void OnMouseOver()
    {
        if (Input.GetMouseButton(0) && canShoot && !gameLost)
        {
            scale.x -= ScalePoint;
            scale.y -= ScalePoint;
            scale.z -= ScalePoint;

            // Invoking ShootingBall ChangeScale method with ScalePoints
            changeScaleEvent.Invoke(ScalePoint*2f);
            changePathSizeEvent.Invoke(ScalePoint);
        }  
    }

    // Adds Impulse to ShootingBall object when touch released
    void OnMouseUp()
    {
        if(canShoot)
        {
            // Invoking ShootingBall AddImpulse method
            addForceEvent.Invoke();
            gameObject.GetComponent<SphereCollider>().radius = colliderRadius;
            canShoot = false;
        }
    }

    void OnTriggerEnter(Collider trigger)
    {
        /* Invoking gameWon event. Freezing player ball position 
            and setting player ball object`s velocity to zero */ 
        if(trigger.gameObject.CompareTag("Castle"))
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            gameWonEvent.Invoke(true);
            EventManager.RemoveGameWonInvoker(this);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
    #endregion

    #region Private methods
    void ChangeShootingState(bool state) 
    {
        canShoot = state;    
    }

    void ChangeMoveToDoorState(bool state)
    {
        canMoveToDoorState = state;
    }

    void MoveToDoor()
    {
        // Move PlayerBall object
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5f), ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        
    }
    #endregion

    #region Event methods
    public void AddAddForceListener(UnityAction listener)
    {
        addForceEvent.AddListener(listener);
    }

    public void AddChangeScaleListener(UnityAction<float> listener)
    {
        changeScaleEvent.AddListener(listener);
    }

    public void AddChangePathSizeListener(UnityAction<float> listener)
    {
        changePathSizeEvent.AddListener(listener);
    }

    public void AddGameWonListener(UnityAction<bool> listener)
    {
        gameWonEvent.AddListener(listener);
    }

    public void AddGameLostListener(UnityAction<bool> listener)
    {
        gameLostEvent.AddListener(listener);
    }
    #endregion
}
