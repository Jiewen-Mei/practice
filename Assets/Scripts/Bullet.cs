using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

	public float speed = 10f;
	public float maxLifetime = 2f;
	public float bulletDamage = 10f;
	[SerializeField] private HealthManager healthController;
	private Rigidbody2D bullet;
	[SerializeField] private BirdHit BirdHit;
	
	private void Awake()
	{
		bullet = GetComponent<Rigidbody2D>();

	}
  
	public void Project(Vector2 direction)
	{
		bullet.AddForce(direction * speed);
		Destroy(this.gameObject, this.maxLifetime);
	}
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "bird"){
			soundsManager.PlaySound("bird_wahhh");
			DamageBird();
			this.gameObject.SetActive(false);
			if(healthController.birdHealth <=0f){
				Destroy(other.gameObject);
			}
			
		}
	}
	void DamageBird()
	{
		BirdHit.TriggerAnimation(	);
		healthController.birdHealth = healthController.birdHealth - bulletDamage;
		
		if(healthController.birdHealth <=0){
			healthController.birdHealth = 0;
			MainManager.score = MainManager.score+(healthController.playerHealth*0.5f*MainManager.difficulty)+25f;
			healthController.UpdateHealth();
			if(healthController.playerHealth >0){
			MainManager.level = MainManager.level+1f;
			if(MainManager.level>=MainManager.maxLevel){
				MainManager.SaveScore();
				Invoke("MaxLevel",1f);
			}
			else{
				Invoke("reset",1f);
			}
			}
		}
		healthController.UpdateHealth();
		
			
		
	}
	
	public void reset(){
		Debug.Log("Bird Dead, restarting ");
		Destroy(GameObject.FindWithTag("bird"));
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		Destroy(this.gameObject);
	}
	public void MaxLevel(){
		Debug.Log("MaxLevel reset");
		Destroy(GameObject.FindWithTag("bird"));
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene("Menu");
		Destroy(this.gameObject);
	}
}
