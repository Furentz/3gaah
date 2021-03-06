using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3ControlerScript : MonoBehaviour {

	//Controls for player 3 (SciBot)

	public float maxSpeed = 10f;
	public float maxSpeedV = 100f;
	bool facingRight = true;
	private Rigidbody2D rigi;
	Transform playerGraphics;


	private void Awake()
	{
		rigi = GetComponent<Rigidbody2D> ();
		playerGraphics = transform.Find ("SciBotGraph");
		if (playerGraphics == null) {
			Debug.LogError ("Let's freak out! There is no 'Graphics' object as a child of the player");
		}	
	}



	Animator anim;

	bool grounded = false;
	public Transform SciBotGrndChk;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 0;


	//initialisation
	void Start () {
		anim = GetComponent<Animator> ();
	}

	//update
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (SciBotGrndChk.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		float moveV = Input.GetAxis ("Vertical2");
		float move = Input.GetAxis ("Horizontal2");
	
		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigi.velocity = new Vector2 (move * maxSpeed, moveV * maxSpeedV);


		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			//Adds nano to the nanocell bar by draining nanocell from objects
			GameObject.Find ("Canvas").GetComponent<UserInterface>().RemoveNano(-10);
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
