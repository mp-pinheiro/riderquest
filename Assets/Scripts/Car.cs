using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	float acceleration = 10f;
	float reverseAccel;
	float brake = 2f;
	float turn = 200f;
	float driftTurn = 0.5f;
	float dritfSpeed = 3f;
	bool drifting;
	bool turning;
	public GameObject spriteObject;
	Animator anim;
	ParticleSystem particle;
	protected Rigidbody2D rb;

	protected virtual void Awake(){
		rb = GetComponent<Rigidbody2D>();
		rb.drag = 1f;
		reverseAccel = acceleration/5f;
		drifting = false;
		anim = spriteObject.GetComponent<Animator>();
		particle = GetComponentInChildren<ParticleSystem>();
	}

	protected virtual void Update(){
		//remove rotation momentum
		rb.angularVelocity = 0f;

		//set animation and angle
		rb.rotation -= 360f*Mathf.Floor(rb.rotation/360f); //lua-like mod
		int exactAngle = 45*Mathf.RoundToInt(rb.rotation/45f)%360;
		spriteObject.transform.rotation = Quaternion.Euler(0f, 0f, rb.rotation-exactAngle);
		anim.SetFloat("angle", rb.rotation);

		//loop
		/*
		if(rb.position.x<-9f){
			rb.position = new Vector2(rb.position.x+18f, rb.position.y);
		}
		if(rb.position.x>9f){
			rb.position = new Vector2(rb.position.x-18f, rb.position.y);
		}
		if(rb.position.y<-5f){
			rb.position = new Vector2(rb.position.x, rb.position.y+10f);
		}
		if(rb.position.y>5f){
			rb.position = new Vector2(rb.position.x, rb.position.y-10f);
		}
		*/
	}

	protected virtual void FixedUpdate () {
		float angle = Vector2.Angle(rb.velocity, GetDirection());
		if(rb.velocity.magnitude>=dritfSpeed && angle>45f){
			//start drifting
			drifting = true;
		}
		if((angle<30f && !turning) || rb.velocity.magnitude<dritfSpeed){
			//stop drifting
			drifting = false;
		}
		
		var em = particle.emission;
		em.enabled = drifting;
	}

	void LateUpdate(){
		spriteObject.transform.position = transform.position;
	}

	protected void Accelerate(){
		rb.AddForce(GetDirection()*acceleration);
	}
	protected void Reverse(){
		rb.AddForce(-GetDirection()*reverseAccel);
	}

	protected void Brake(){
		Vector2 dir1 = rb.velocity;
		rb.AddForce(-dir1*brake);
	}

	void Turn(int dir){
		turning = true;
		float scale = drifting? turn*driftTurn : turn;
		rb.rotation += dir*scale*Time.deltaTime;
	}

	protected void TurnLeft(){
		Turn(1);
	}

	protected void TurnRight(){
		Turn(-1);
	}

	protected void StopTurning(){
		turning = false;
	}

	Vector2 GetDirection(){
		float angle = rb.rotation*Mathf.PI/180f;
		return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}
}
