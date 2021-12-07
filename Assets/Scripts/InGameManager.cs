using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for calling UI scripts
using UnityEngine.SceneManagement;


public class InGameManager : MonoBehaviour {

	[SerializeField] Transform UIPanel; //Will assign our panel to this variable so we can enable/disable it
	[SerializeField] Text difficultyText;
	

	bool isPaused; //Used  to determine paused state

	void Start ()
	{
		UIPanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
		isPaused = false; //make sure isPaused is always false when our scene opens
		soundsManager.Volume = MainManager.volume;
		switch(MainManager.difficulty){
			case 0:
				difficultyText.text = "Easy";
				break;
			case 1:
				difficultyText.text = "Medium";
				break;
			case 2: 
				difficultyText.text = "Hard";
				break;
			default:
				difficultyText.text = "WTF?";
				break;
		}
		
	}

	void Update ()
	{



		//If player presses escape and game is not paused. Pause game. If game is paused and player presses escape, Resume.
		if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
			Pause();
		else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
			Resume();
	}

	public void Pause()
	{
		isPaused = true;
		UIPanel.gameObject.SetActive(true); //turn on the pause menu
		Time.timeScale = 0f; //pause the game
	}

	public void Resume()
	{
		isPaused = false;
		UIPanel.gameObject.SetActive(false); //turn off pause menu
		Time.timeScale = 1f; //resume game
	}

		public void Menu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1f;
		isPaused = false;
	}

	public void Restart()
	{
		Scene scene = SceneManager.GetActiveScene();
		
		SceneManager.LoadScene(scene.name);
		Resume();
	}
}

