using UnityEngine;
using System.Collections;

public class GeometryActivation : A_Activation {
	public override void Execute(Collider collision){
		gameManager.FlatWareIncrement(collision);
	}
}