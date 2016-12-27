using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperiencePageController : Page_Base {
	[SerializeField]private Scrollbar scrollbar;

	void Awake(){
		
	}

	void Start () {
		
	}

	protected override void OnClose(){
	}

	protected override void OnOpen(){
		scrollbar.value = 1;
	}
		
	void Update () {
		
	}
}
