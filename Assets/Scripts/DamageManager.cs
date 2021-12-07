using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour
{
	
	[SerializeField] private float birdDamage = 10.0f;
	[SerializeField] private float playerDamage = 10.0f;
	[SerializeField] private HealthManager healthController;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			DamagePlayer();
		}
		else if(collision.CompareTag("Bird"))
		{
			DamageBird();
		}
			
	}

    void DamagePlayer()
	{
		healthController.playerHealth = healthController.playerHealth - birdDamage;
		healthController.UpdateHealth();
	}
	
	void DamageBird()
	{
		
	}
}
