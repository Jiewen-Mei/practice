using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

	[SerializeField] HealthManager healthinfo;
	
	public static MainManager Instance;
	public static string playername = "Unknown";
	
	public const int NUM_HIGH_SCORES = 5;
    public const string NAME_KEY = "HSName";
    public const string SCORE_KEY = "HScore";
	public static float volume = 1f;
	public static float score = 0f;
	public static float level = 1f; 
	public static float maxLevel = 4f;
	public static int difficulty = 0;

	
	private void Awake()
	{
		if(Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
		
	
	public static void SaveScore()
    {
		Debug.Log("Saving Scores...");
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;
			Debug.Log("Name: " + currentNameKey + "\n Score: " + currentScoreKey);

            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                float currentScore = PlayerPrefs.GetFloat(currentScoreKey);
                if (score > currentScore)
                {
                    float tempScore = currentScore;
                    string tempName = PlayerPrefs.GetString(currentNameKey);

                    PlayerPrefs.SetString(currentNameKey, playername);
                    PlayerPrefs.SetFloat(currentScoreKey, score);

                    score = tempScore;
                    playername = tempName;
                }
            }

            else
            {
                PlayerPrefs.SetString(currentNameKey, playername);
                PlayerPrefs.SetFloat(currentScoreKey, score);
                return;
            }
        }
    }

}

