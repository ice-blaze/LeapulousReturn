using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResetScript : MonoBehaviour {


	public List<GameObject> gameObjects;
	List<ObjectPosition> resetPositions = new List<ObjectPosition>();

	void Start(){
		foreach(GameObject g in gameObjects){
			resetPositions.Add(new ObjectPosition(g));
		}
	}

	void OnTriggerEnter(Collider other) {
		StartCoroutine("Disable");
		ResetAllObjects();

	}

	void ResetAllObjects(){
		foreach(ObjectPosition g in resetPositions){
			g.ResetPosition();
		}
	}

	IEnumerator Disable() {
		MeshRenderer[] childs = GetComponentsInChildren<MeshRenderer>();

		renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,0);
		foreach (MeshRenderer child in childs){
			child.renderer.enabled = false;
		}

		yield return new WaitForSeconds(1);
		renderer.material.color = new Color(renderer.material.color.r,renderer.material.color.g,renderer.material.color.b,1);
		foreach (MeshRenderer child in childs){
			child.renderer.enabled = true;
		}
	}
}
