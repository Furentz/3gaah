using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rigi;
	Transform playerGraphics;
	private AudioClip milbotTrackSound;


	private void Awake()
	{
		rigi = GetComponent<Rigidbody2D> ();
		playerGraphics = transform.Find ("MilBotGraph");
		if (playerGraphics == null) {
			Debug.LogError ("Let's freak out! There is no 'Graphics' object as a child of the player");
		}	
	}



	Animator anim;

	bool grounded = false;
	public Transform MilBotGrndChk;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;


	//initialisation
	void Start () {
		anim = GetComponent<Animator> ();
	}

	//update
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (MilBotGrndChk.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		float move = Input.GetAxis ("Horizontal3");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if (grounded && Input.GetKeyDown (KeyCode.X))
		{
			anim.SetBool("Ground", false);
			rigi.AddForce(new Vector2(0, jumpForce));
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = playerGraphics.localScale;
		theScale.x *= -1;
		playerGraphics.localScale = theScale;

	}

}
