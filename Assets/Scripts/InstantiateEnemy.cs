using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateEnemy : MonoBehaviour {
	private GameObject bullet; 
	public GameObject raycastCamera;
	private float spawTime = 5; 
	private float x, y, z, raio = 10;
	private List<GameObject> inimigos;
	 
	// Use this for initialization
	void Start () 
	{
		inimigos = new List<GameObject> ();
	}

	// começa o jogo, instancia os inimigos e os adiciona na lista de poll.
	public void StartGame()
	{
		raycastCamera.GetComponent<RaycastCamera> ().text.GetComponent<Text>().text = "Score: 0";
		if (inimigos.Count < 1) 
		{
			for (int i = 0; i < 10; i++)
			{
				GameObject ob = Instantiate (Resources.Load ("Enemy", typeof(GameObject))) as GameObject;
				ob.SetActive (false);
				inimigos.Add (ob);
			}
		}
		InvokeRepeating ("Spaw", 0, spawTime);
	}

	//para o jogo e desabilita o spaw de inimigos
	public void EndGame()
	{
		raycastCamera.GetComponent<RaycastCamera> ().points = 0;
		gameObject.transform.rotation = new Quaternion (0, 0, 0, 0);
		CancelInvoke ("Spaw");
		for (int i = 0; i < 10; i++) 
		{
			inimigos[i].SetActive (false);
		}
	}

	//fecha a aplicação
	public void CloseApllication()
	{
		Application.Quit ();
	}

	// habilita um inimigo e o posiciona na superficie de uma esfera de raio 10
	void Spaw()
	{
		for (int i = 0; i < 10; i++) 
		{
			if (!inimigos [i].activeInHierarchy) 
			{
				z = Random.Range (-raio, raio);
				y = Mathf.Sqrt(raio * raio - z * z);
				y =	Random.Range (-y, y);
				x =	Mathf.Sqrt( raio*raio - ((z*z) + (y*y))); 
				inimigos [i].transform.position = new Vector3 (x, y, z);
				inimigos [i].SetActive (true);
				break;
			}
		}
	}
}
