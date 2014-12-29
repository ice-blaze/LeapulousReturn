using UnityEngine;
using System.Collections;

public class ObjectPosition{
	Vector3 startPosition;
	GameObject gameObj;

	public ObjectPosition(GameObject _gameObj){
		gameObj = _gameObj;
		startPosition = gameObj.transform.position;
	}

	public void ResetPosition(){
		gameObj.transform.position = startPosition;
	}
}
