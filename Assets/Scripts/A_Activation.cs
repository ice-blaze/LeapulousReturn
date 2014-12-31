using UnityEngine;

public abstract class A_Activation : MonoBehaviour
{
	public GameObject form;
	protected GameManager gameManager;

	void Start(){
//		gameManager = GameObject.Find("UIManager").GetComponent<GameManager>();
	}
	
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject == form) {
			Execute(collision);
		}
	}

	public abstract void Execute(Collider coll);
}