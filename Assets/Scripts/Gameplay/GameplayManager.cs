using UnityEngine;
using UnityEngine.Events;

public class GameplayManager : MonoBehaviour
{
    #region Fields
    [SerializeField]
    GameObject playerBall;
    [SerializeField]
    GameObject pathQuad;
    [SerializeField]
    GameObject castle;
    [SerializeField]
    GameObject shootingBall;
    [SerializeField]
    GameObject door;

    CanShootEvent canShootEvent = new CanShootEvent();
    
    bool gameLost = false;
    bool gameWon = false;
    bool endGame = false;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        // Setting 60 frames per second lock
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        EventManager.AddCanShootInvoker(this);
        EventManager.AddGameLostListener(GameLost);
        EventManager.AddGameWonListener(GameWon);

        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawning a new shooting ball object and setting canShoot flag to true
        if (GameObject.FindGameObjectsWithTag("ShootingBall").Length == 0)
		{
            Instantiate(shootingBall);
            canShootEvent.Invoke(true);
		}

        // Spawning game over message object 
        if(gameLost && !endGame)
        {
            endGame = !endGame;
            GameObject gameOverMessage = Instantiate(Resources.Load("MenuPrefabs/GameOver")) as GameObject;
        }

        // Spawning game over message object 
        if(gameWon && !endGame)
        {
            endGame = !endGame;
            GameObject gameOverMessage = Instantiate(Resources.Load("MenuPrefabs/GameOver")) as GameObject;
        }
    }
    #endregion

    #region Private methods
    void GenerateLevel()
    {
        // Spawning PlayerBall object
        Instantiate(playerBall);
        // Spawning ShootingBall object
        Instantiate(shootingBall);
        // Spawning PathQuad object
        Instantiate(pathQuad);
        // Spawning Castle object
        Instantiate(castle);
        // Spawning Door object
        Instantiate(door);
    }

    void GameWon(bool state)
    {
        gameWon = state;
    }

    void GameLost(bool state)
    {
        gameLost = state;
    }
    #endregion

    #region Event methods
    public void AddCanShootListener(UnityAction<bool> listener)
    {
        canShootEvent.AddListener(listener);
    }
    #endregion
}
