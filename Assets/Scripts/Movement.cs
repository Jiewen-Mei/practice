
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	
	[SerializeField] Bullet bulletPrefab;
    [SerializeField] float movement;
	[SerializeField] float moveVertical;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10.0f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
		
    }

    // Update is called once per frame; best for user input
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
	    moveVertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			shoot();
		}
    }

    //FixedUpdate is called potentially multiple times per frame; best for physics and movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * speed, moveVertical * speed);
		
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded) //only allow Mario to jump if he is on the ground -- no double jumps 
            Jump();
    }

    private void Flip()
    {

        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;

    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        jumpPressed = false;
        isGrounded = false; 
    }

    //when we collide with the ground (here our ramp), we want to note that Mario is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

	private void shoot(){
		Bullet bullet = Instantiate(this.bulletPrefab,this.transform.position, this.transform.rotation);
	
		bullet.Project(transform.right);
		
	}


}
