using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	private Transform playerTranform;
	private float velocity = 10;
	private Vector3 vetorDirecao;
	private ParticleSystem explosion;
	private Rigidbody rigid;
	private RaycastInteractive startEvent;

	// inicialização dos inimigos para irem em direção ao player
	void OnEnable () 
	{
		explosion = gameObject.GetComponent<ParticleSystem> ();
		rigid = gameObject.GetComponent<Rigidbody> ();
		playerTranform = GameObject.Find ("Player").GetComponent<Transform> ();
		vetorDirecao = playerTranform.position - transform.position;
		rigid.velocity = vetorDirecao/5;
	}

	void OnCollisionEnter(Collision obj)
	{
		startEvent = obj.collider.GetComponent<RaycastInteractive> ();
		startEvent.completeFill.Invoke ();
	}

	//reseta o inimigo para ser utilizado novamente
	public void ResetEnemy()
	{
		explosion.Play ();
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<Collider> ().enabled = false;
		Invoke ("Disable", 1f);
	}
		
	void Disable ()
	{
		gameObject.SetActive (false);
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<Collider> ().enabled = true;
	}
}
