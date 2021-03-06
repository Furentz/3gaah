using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ControlerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	private Rigidbody2D rigi;
	Transform player2Graphics;


	private void Awake()
	{
		rigi = GetComponent<Rigidbody2D> ();
		player2Graphics = transform.Find ("EngBotGraph");
		if (player2Graphics == null) {
			Debug.LogError ("Let's freak out! There is no 'Graphics' object as a child of the player");
		}	
	}



	Animator anim;

	bool grounded = false;
	public Transform EngBotGrndChk;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;


	//initialisation
	void Start () {
		anim = GetComponent<Animator> ();
	}

	//update
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle (EngBotGrndChk.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigi.velocity = new Vector2(move * maxSpeed, rigi.velocity.y);

		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}


	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Q))
		{
		anim.SetBool ("Building", true);
		}
		if (grounded && Input.GetKeyUp (KeyCode.Q))
			anim.SetBool ("Building", false);
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = player2Graphics.localScale;
		theScale.x *= -1;
		player2Graphics.localScale = theScale;

	}

}
