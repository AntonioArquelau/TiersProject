using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform playerTranform;
	private float velocity = 10;
	private Vector3 teste;
	private Rigidbody rigid;

	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
		playerTranform = GameObject.Find ("Player").GetComponent<Transform> ();
		teste = playerTranform.position - transform.position;
		rigid.velocity = teste/5;
		Debug.Log (teste);	
	}

	void OnCollisionEnter(Collision obj){
		gameObject.SetActive (false);
	}
}
