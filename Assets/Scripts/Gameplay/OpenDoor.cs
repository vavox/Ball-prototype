using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    #region Fields
    bool gameWon = false;
    
    Vector3 doorRotationVector = Vector3.zero;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGameWonListener(GameWon);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(gameWon)
        {
            DoorAnimation();
        }
    }
    #endregion

    #region Private methods 
    void DoorAnimation()
    {
        float degreePerSecond = 30f * Time.deltaTime;
        bool canRotate = true;
        if(gameObject.transform.rotation.eulerAngles.y > 120)
        {
            canRotate = !canRotate;
        }

        if(canRotate) { gameObject.transform.Rotate(Vector3.up, degreePerSecond); }
    }

    void GameWon(bool state)
    {
        gameWon = state;
    }
    #endregion
}
