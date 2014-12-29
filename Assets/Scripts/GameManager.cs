using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	int flatWareCounter = 0;
	HashSet<Collider> flatWareHash = new HashSet<Collider>();
	HashSet<Collider> geometryHash = new HashSet<Collider>();
	int basketPoint = 0;
	GameObject[] hudTexts;
	Animator[] animators;


	// Use this for initialization
	void Start () {
		hudTexts = GameObject.FindGameObjectsWithTag("HUDText");
		animators = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void BasketPoint(Collider collider){
		if(collider.rigidbody.velocity<0){
			basketPoint++;
			HudDisplay("Bravo !\nYou score a point\nTotal : "+ basketPoint.ToString() +" !");
		}
	}

	public void GeometryIncrement(Collider collider){
		geometryHash.Add(collider);
		
		if(geometryHash.Count==3){
			geometryHash.Clear();
			HudDisplay("Bravo !\nGeometry puzzle\nsolve !");
		}
	}

	public void FlatWareIncrement(Collider collider){
		flatWareHash.Add(collider);

		// TODO if an object enter one time in the collider then it's considiered in
		// but we can have the case where the object go juste trough our collider
		// so if we want to do something correct we have to verify for each collision
		// if all the other object are still in their collider
		if(flatWareHash.Count==3){
			flatWareHash.Clear();
			HudDisplay("Bravo !\nFlatware puzzle\nsolve !");
		}
	}

	void HudDisplay(string message){
		foreach(GameObject g in hudTexts){
			g.GetComponent<Text>().text = message;
		}
		foreach(Animator a in animators){
			a.SetTrigger("StartFadeIn");
		}
	}
}
