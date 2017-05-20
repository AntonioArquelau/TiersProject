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
	void Start () {
		initialMiraPosition = mira.position;
	}

	void Update () {
		ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
		if (Physics.Raycast (ray, out hit, alcance)) 
		{
			SetPosition (hit);
			if (hit2 != hit.collider) 
			{
				hit2 = hit.collider;
				corrotina = LoadDestroy ();
				StartCoroutine (corrotina);
				Debug.Log (hit.collider.name);
			}
		} 
		else 
		{
			hit2 = null;
			if (corrotina != null) {
				StopCoroutine (corrotina);
			}
			load.fillAmount = 0;
			mira.position = initialMiraPosition;

		}

		if (load.fillAmount == 1) {
			startEvent = hit.collider.GetComponent<RaycastInteractive>();
			startEvent.completeFill.Invoke ();
			StopCoroutine (corrotina);
			load.fillAmount = 0;
			mira.position = initialMiraPosition;
		}

	}

	public void SetPosition (RaycastHit hit)
	{
		mira.position = hit.point;
		mira.localScale = Vector3.one * hit.distance/10;
	}

	IEnumerator LoadDestroy(){
		while (hit2 != null) 
		{
			load.fillAmount += 0.02f; 
			yield return new WaitForSeconds (0.01f);
		} 
	}

}
