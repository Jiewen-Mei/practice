using UnityEngine;

public class enemyMove : MonoBehaviour
{
	
    //movement speed in units per second
	public Feather featherPrefab;
    private float XmovementSpeed = -3f;
	private float YmovementSpeed = 2f;
	private float attackDelay = 1.5f / (1f+MainManager.level*0.5f+MainManager.difficulty);
	private float xPos;
	private float yPos;
	private bool isFacingLeft = true;
	
	private Transform target;
	// Start is called before the first frame update
	
	
    void Start(){
		InvokeRepeating("LaunchProjecttile", 1.0f, attackDelay);
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	void Update(){
		if(MainManager.level >=3){
			if(target){
			transform.position = Vector2.MoveTowards(transform.position, target.position, 3f* (float)Time.deltaTime );
			}		
		}
		else{
			transform.position = transform.position + new Vector3(XmovementSpeed * (float)Time.deltaTime, YmovementSpeed * (float) Time.deltaTime, 0f);
			xPos = GameObject.FindGameObjectWithTag("bird").transform.position.x;
			yPos = GameObject.FindGameObjectWithTag("bird").transform.position.y;
	
			
		}
	
	}
	private void FixedUpdate()
    {
		if(( (xPos< -10f && isFacingLeft) ||  (xPos > 10f && !isFacingLeft)) && MainManager.level<=2){
		Flip();
		} 
		if(yPos<-3f || yPos>3f){
			Bounce();
		}
		if(MainManager.level >=3){
		if((target.position.x - transform.position.x)>0 && isFacingLeft  || (target.position.x - transform.position.x)<0 && !isFacingLeft ){
			Flip();
			}
		}
    }
	 private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingLeft = !isFacingLeft;
		XmovementSpeed = XmovementSpeed * (-1); 
    }
	private void Bounce(){
		YmovementSpeed = YmovementSpeed * (-1);
		
	}
	void LaunchProjecttile(){
		Feather Fclone = Instantiate(this.featherPrefab,this.transform.position, this.transform.rotation);
	
		Fclone.Project(-transform.right);
	}
	
}
