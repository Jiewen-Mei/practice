	
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Feather : MonoBehaviour
{
	
	public float speed = 100f;
	public float maxLifetime = 1.5f;
	public float featherDamage = 10f * (1f+MainManager.level+MainManager.difficulty);
	[SerializeField] private HealthManager healthController;
	[SerializeField] private Explosion Explosion;
	
	private Rigidbody2D feather;

	private void Awake()
	{
		feather = GetComponent<Rigidbody2D>();
		featherDamage = 10f * (1f+MainManager.level+MainManager.difficulty); 
	}
  
	public void Project(Vector2 direction)
	{
		feather.AddForce(direction * speed);
		transform.Rotate(0, 0, -90);
		Destroy(this.gameObject, this.maxLifetime);
	}
	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			soundsManager.PlaySound("crashSound");
			if(healthController.birdHealth>0){
			DamagePlayer();
			if(healthController.playerHealth <=0){
				TriggerAnimation();
				MainManager.score = MainManager.score - 15;
				
				Invoke("reset",0.5f);
			}
			}
		}
	}
	void DamagePlayer()
	{
		healthController.playerHealth = healthController.playerHealth - featherDamage;
		if(healthController.playerHealth <=0){
			healthController.playerHealth = 0;
		}
		healthController.UpdateHealth();
	}
	public void TriggerAnimation(){
		Explosion.TriggerAnimation();
	}
	public void reset(){
		Debug.Log("restarting");
		Destroy(GameObject.FindWithTag("Player"));
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		Destroy(this.gameObject);
	}
}