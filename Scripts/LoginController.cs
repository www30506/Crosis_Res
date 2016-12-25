using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : MonoBehaviour {
	[SerializeField]private TextPlayer textPlayer;

	void Start () {
		textPlayer.Play ();
		StartCoroutine (IE_WaitToLobbyScene ());
	}

	void Update () {
		
	}

	IEnumerator IE_WaitToLobbyScene(){
		yield return new WaitForSeconds (6.5f);
		textPlayer.GetComponent<UTweenColor> ().ReSetToStart ();
		textPlayer.GetComponent<UTweenColor> ().enabled = true;
		yield return new WaitForSeconds (1.5f);
		Scene.LoadScene (SceneName.Lobby);
	}
}
