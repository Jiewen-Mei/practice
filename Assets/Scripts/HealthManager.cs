using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
   public float playerHealth;
   public float birdHealth;
   [SerializeField] private Text playerHealthText;
   [SerializeField] private Text birdHealthText;
   [SerializeField] private Text scoreText;
   [SerializeField] private Text playername;
   [SerializeField] private Text levelText;
   private float score = MainManager.score;
   void Start()
   {
	   UpdateHealth();
   }
   public void UpdateHealth()
   {
	   playerHealthText.text = "Player Health:"+ playerHealth.ToString("0");
	   birdHealthText.text = "Enemy health:" + birdHealth.ToString("0");
	   
		   
	   scoreText.text = "Score: "+ score.ToString("0");
	   playername.text = "Name: "+MainManager.playername;
	   levelText.text = "Level: "+MainManager.level.ToString("0");
   }
}
