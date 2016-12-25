using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Other/TextPlayer")]
public class TextPlayer : MonoBehaviour {
	private Text text;
	private string allStr;
	[SerializeField]private int oneSecondWords = 10;
	[SerializeField]private bool startHide= true;

	void Awake(){
		text = this.GetComponent<Text> ();
		allStr = text.text;

		if (startHide) {
			text.text = "";
		}
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void Play(){
		StartCoroutine (IE_Play ());
	}

	IEnumerator IE_Play(){
		char[] chars = allStr.ToCharArray ();
		float _distanceTime = 1/(float) oneSecondWords;
		int _showWordsCount = 0;
		string _str = "";

		while(_showWordsCount < chars.Length){
			float _tempTime = 0.0f;

			while (_tempTime < _distanceTime) {
				_tempTime += Time.deltaTime;
				yield return null;
			}

			_str += chars [_showWordsCount++];
			text.text = _str;
		}
		yield return null;
	}
}
