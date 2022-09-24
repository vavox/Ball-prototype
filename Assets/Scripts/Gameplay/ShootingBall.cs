using UnityEngine;
using UnityEngine.Events;

public class ShootingBall : MonoBehaviour
{
    #region Fields
    SetAreaEvent setAreaEvent = new SetAreaEvent();
    Vector3 scale = Vector3.zero;

    const float Velocity = 75f;
    const float DefaultRadius = 0.5f;
    float disableArea;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddSetAreaInvoker(this);
        EventManager.AddAddForceListener(AddImpulse);
        EventManager.AddChangeScaleListener(ChangeScale);

        disableArea = DefaultRadius * gameObject.transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Private methods
    void AddImpulse()
    {
        Vector3 ballVelocity = new Vector3(0, 0, Velocity);
        gameObject.GetComponent<Rigidbody>().AddForce(ballVelocity, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        disableArea = DefaultRadius * gameObject.transform.localScale.x / 2;

        setAreaEvent.Invoke(disableArea);
        EventManager.RemoveSetAreaInvoker(this);
    }

    void ChangeScale(float scalePoint)
    {
        scale.x += scalePoint;
        scale.y += scalePoint;
        scale.z += scalePoint;

        gameObject.transform.localScale = scale;
        gameObject.GetComponent<SphereCollider>().radius = DefaultRadius;
    }
    #endregion

    #region Event methods
    public void AddSetAreaListener(UnityAction<float> listener)
    {
        setAreaEvent.AddListener(listener);
    }
    #endregion
}
