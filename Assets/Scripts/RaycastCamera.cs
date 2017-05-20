using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastCamera : MonoBehaviour {
	public float alcance;
	private Ray ray;
	private IEnumerator corrotina;
	private RaycastHit hit;
	private RaycastInteractive startEvent;
	private Collider hit2;
	public Image load;
	public Transform mira;
	public Vector3 initialMiraPosition;
	public int points = 0;
	public GameObject text;
	void Start () {
		initialMiraPosition = mira.localPosition;
	}

	void Update () 
	{
		ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
		if (Physics.Raycast (ray, out hit, alcance)) 
		{
			SetPosition (hit);
			if (hit2 != hit.collider) 
			{
				hit2 = hit.collider;
				corrotina = LoadDestroy ();
				StartCoroutine (corrotina);
			}
		} 
		else 
		{
			hit2 = null;
			if (corrotina != null) 
			{
				StopCoroutine (corrotina);
			}
			load.fillAmount = 0;
			mira.localPosition = initialMiraPosition;
		}
		if (load.fillAmount == 1) 
		{
			if (hit.collider.gameObject.name == "Start") 
			{
				startEvent = hit.collider.GetComponent<RaycastInteractive> ();
				startEvent.completeFill.Invoke ();
				mira.localPosition = initialMiraPosition;	
			} 
			else if (hit.collider.gameObject.name == "Exit") 
			{
				mira.localPosition = initialMiraPosition;
				startEvent = hit.collider.GetComponent<RaycastInteractive> ();
				startEvent.completeFill.Invoke ();
			} 
			else 
			{
				points++;
				text.GetComponent<Text>().text = "Score: " + points;
				startEvent = hit.collider.GetComponent<RaycastInteractive> ();
				startEvent.completeFill.Invoke ();
				StopCoroutine (corrotina);
				load.fillAmount = 0;
				mira.localPosition = initialMiraPosition;
				mira.localScale = Vector3.one;
			}
		}

	}
	public void SetPosition (RaycastHit hit)
	{
		mira.position = hit.point;
		mira.localScale = Vector3.one * hit.distance/10;
	}
	IEnumerator LoadDestroy()
	{
		while (hit2 != null) 
		{
			load.fillAmount += 0.02f; 
			yield return new WaitForSeconds (0.01f);
		} 
	}
}
