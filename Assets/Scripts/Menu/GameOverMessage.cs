using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverMessage : MonoBehaviour
{
    #region Fields
    [SerializeField]
    TextMeshProUGUI messageText;

    const string LosingMessage = "You Lost!";
    const string WinningMessage = "You Won!";

    bool gameLost = false;
    #endregion

    #region Unity methods
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddGameLostListener(GameLost);
    }

    // Update is called once per frame
    void Update()
    {
        SetMessage();
    }
    #endregion

    #region Public methods
    public void SetMessage()
    {
        if(gameLost)
        {
            messageText.text = LosingMessage;
        }
        else
        {
            messageText.text = WinningMessage;
        }
 
    }
    public void RestartGame()
    {
        // Destroy message, and reload gameplay scene
        Time.timeScale = 1;
        Destroy(gameObject);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Gameplay");
    }

    // Moves to main menu when exit button clicked
    public void QuitGame()
    {
        // Destroy message, and go to menu
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
    }

    void GameLost(bool state)
    {
        gameLost = state;
    }
    #endregion
}
