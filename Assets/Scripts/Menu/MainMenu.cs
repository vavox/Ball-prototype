using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	#region Public methods
	// Goes to the gameplay
	public void GoToGameplay()
    {
		SceneManager.LoadScene("Gameplay");
    }

	// Quits the game
	public void QuitGame()
	{
		Application.Quit();
	}
	#endregion
}
