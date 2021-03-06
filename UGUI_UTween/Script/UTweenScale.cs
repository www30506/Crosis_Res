﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

[AddComponentMenu("UI/Tween/TweenScale")]
public class UTweenScale : UTweener {
	protected SclingDelegate[] scaleType = new SclingDelegate[3];
	public Vector3 Form = new Vector3(1,1,1), To = new Vector3(1,1,1);
	protected Vector3 distanceVector, tempVector;

	void Start(){
		scaleType [0] = new SclingDelegate(OnceScling);
		scaleType [1] = new SclingDelegate(LoopScling);
		scaleType [2] = new SclingDelegate(PingPong);
		distanceVector = To - Form;

	}

	void OnEnable(){
		distanceVector = To - Form;
	}

	void LateUpdate () {
		if (start) {
			Scling ();
		}
	}

	private void Scling(){
		time += ignoreTimeScale? Time.unscaledDeltaTime : Time.deltaTime;
		scaleType [(int)loopType]();
	}

	public delegate void SclingDelegate();
	public void OnceScling(){
		tempVector = distanceVector * Curve.Evaluate(time*percent);
		tempVector = Form + tempVector;
		myRectTransfrom.localScale = tempVector ;

		if (time > Duration) {
			start = false;
			myRectTransfrom.localScale = To;
			OnFinished();
			this.enabled = false;
		}
	}

	public void LoopScling(){
		tempVector = distanceVector * Curve.Evaluate (time * percent);
		tempVector = Form + tempVector;
		myRectTransfrom.localScale = tempVector;

		if (time > Duration) {
			time = 0;
		}
	}

	public void PingPong(){
		if (pingpong) 
			tempVector = distanceVector * Curve.Evaluate ((Duration - time) * percent);
		else 
			tempVector = distanceVector * Curve.Evaluate (time * percent);

		tempVector = Form + tempVector;

		myRectTransfrom.localScale = tempVector;
		if (time > Duration) {
			time = 0;
			pingpong = !pingpong;
		}
	}

}
