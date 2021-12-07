using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for calling UI scripts
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour {

	[SerializeField] Transform MenuPanel; //Will assign our panel to this variable so we can enable/disable it
	[SerializeField] Transform InstructionPanel;
	[SerializeField] Transform SettingPanel;
	[SerializeField] Transform HiScorePanel;
	[SerializeField] Text namefield;
	[SerializeField] Text[] nameTexts;
    [SerializeField] Text[] scoreTexts;
	[SerializeField] Slider Volume;
	[SerializeField] Text VolumeValue;
	[SerializeField] Dropdown Difficulty;
	
	const int easy = 0;
	const int hard = 1 ;
	const int medium = 2;

	bool isPaused; //Used to determine paused state	

	void Start ()
	{
		setFalse();
		if(MainManager.level>=MainManager.maxLevel){
			HiScores();
		}
		else{
			GoBack();
		}
		MainManager.score = 0;
		MainManager.level = 1;
		
		
	}

	public void StartGame()               // load the game scene;
	{
		if(namefield.text == ""){
		MainManager.playername = "Unknown";
		}
		else{
			MainManager.playername = namefield.text;
		}
	
		SceneManager.LoadScene(1);
	}
	public void Instruction(){                       //only intruction panel is active
		MenuPanel.gameObject.SetActive(false); 
		InstructionPanel.gameObject.SetActive(true); 
		SettingPanel.gameObject.SetActive(false);
		HiScorePanel.gameObject.SetActive(false);

	}
	public void Setting(){
		getVolume();
		getDifficulty();
		MenuPanel.gameObject.SetActive(false);        //only setting panel is active
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(true); 
		HiScorePanel.gameObject.SetActive(false);
		

	}
	public void GoBack(){  //back to main menu from other panels
		MenuPanel.gameObject.SetActive(true); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(false);
		HiScorePanel.gameObject.SetActive(false);
	}
	
	public void HiScores(){
		ViewHighScores();
		MenuPanel.gameObject.SetActive(false); 
		InstructionPanel.gameObject.SetActive(false); 
		SettingPanel.gameObject.SetActive(false);
		HiScorePanel.gameObject.SetActive(true);
	}
	
	public void loadScores(){
		
	}
	public void setFalse(){
		MenuPanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
		InstructionPanel.gameObject.SetActive(false); //insstruction is off at start
		SettingPanel.gameObject.SetActive(false); //setting is off at start
		HiScorePanel.gameObject.SetActive(false);
	}
	public void ViewHighScores()
    {
		for (int i = 0; i < MainManager.NUM_HIGH_SCORES; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(MainManager.NAME_KEY + i).ToString();
            scoreTexts[i].text = PlayerPrefs.GetFloat(MainManager.SCORE_KEY + i).ToString();
        }
    }
	public void DeleteScores(){
		for (int i = 0; i < MainManager.NUM_HIGH_SCORES; i++)
        {
            PlayerPrefs.DeleteKey(MainManager.NAME_KEY + i);
            PlayerPrefs.DeleteKey(MainManager.SCORE_KEY + i);
		}
		ViewHighScores();
	}
	public void saveVolume(){
		MainManager.volume = Volume.value;
		VolumeValue.text = (Volume.value*100).ToString("0.0")+"%";
	}
	public void getVolume(){
		Volume.value = MainManager.volume;
		VolumeValue.text = (Volume.value*100).ToString("0.0")+"%";
	}
	
	public void saveDifficulty(){
		MainManager.difficulty = Difficulty.value;
	}
	
	public void getDifficulty(){
		Difficulty.value = MainManager.difficulty;
	}
}
