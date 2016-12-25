using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : MonoBehaviour {

	void Start () {
		PageManerger.CloseAllPage ();
		PageManerger.ChangePage (PageType.MainPage);
	}

	void Update () {
		
	}
}
