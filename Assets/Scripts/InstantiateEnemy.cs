using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour {
	private GameObject bullet; 
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
		InvokeRepeating ("Spaw", 0, 2);
	}

	void Spaw()
	{
		for (int i = 0; i < 10; i++) 
		{
			if (!inimigos [i].activeInHierarchy) {
				inimigos [i].transform.position = new Vector3 (Random.Range (0, 3), Random.Range (0, 3), Random.Range (0, 3));
				inimigos [i].SetActive (true);
				break;
			}
		}
	}
}
