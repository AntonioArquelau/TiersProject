using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour {
	private GameObject bullet; 
	private float spawTime = 2; 
	private float x, y, z, raio=3;
	List<GameObject> inimigos;
	private 
	// Use this for initialization
	void Start () 
	{
		inimigos = new List<GameObject> ();
		for (int i = 0; i < 10; i++) 
		{
			GameObject ob = Instantiate (Resources.Load ("Enemy", typeof(GameObject))) as GameObject;
			ob.SetActive (false);
			inimigos.Add (ob);
		}
		InvokeRepeating ("Spaw", 0, spawTime);
	}

	void Spaw()
	{
		for (int i = 0; i < 10; i++) 
		{
			if (!inimigos [i].activeInHierarchy) {
				x = Random.Range (-raio, raio);
				y =	Random.Range (-raio, raio);
				z = raio*raio - (x*x) - (y*y); 
				inimigos [i].transform.position = new Vector3 (x, y, z);
				inimigos [i].SetActive (true);
				break;
			}
		}
	}
}
