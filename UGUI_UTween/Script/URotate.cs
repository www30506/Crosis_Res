using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("UI/Tween/URotate")]
public class URotate : MonoBehaviour {
	enum RotationType{X, Y, Z};
	enum RotationDirection{Positive, Reverse};
	[SerializeField]RotationType rotationType = RotationType.Z;
	[SerializeField]RotationDirection totatationDirection = RotationDirection.Positive;
	[SerializeField]private float duration = 0;
	private RectTransform thisRectTransform;
	private Vector3 rotattionAngle = new Vector3(0,0,0);

	void Awake(){
		thisRectTransform = this.GetComponent<RectTransform> ();
		if (duration != 0) {
			SetRotationAngle ();
		}
	}

	void Start () {
		
	}
	
	void Update () {
		thisRectTransform.Rotate(rotattionAngle*Time.deltaTime);
	}

	private void Rotate(){
	}

	private void SetRotationAngle(){
		if (rotationType == RotationType.X) {
			rotattionAngle = new Vector3(360 / duration, 0,0);
		}
		else if (rotationType == RotationType.Y) {
			rotattionAngle = new Vector3(0, 360 / duration, 0);
		}
		else {
			rotattionAngle = new Vector3(0,0, 360 / duration);
		}

		if (totatationDirection == RotationDirection.Reverse) {
			rotattionAngle = -rotattionAngle;
		}
	}
}
