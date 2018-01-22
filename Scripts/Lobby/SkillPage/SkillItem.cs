using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour {
	[SerializeField]private Image thisImage;
	[SerializeField]private int skillValue;
	private float moveTime = 0.2f;
	[SerializeField]private Sprite[] Sprites;
	[SerializeField]private Text text;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void SetDate(int p_value, string p_text){
		skillValue = p_value;
		text.text = p_text;
	}

	public void StartAnim(){
		StartCoroutine (IE_StartAnim ());
	}

	IEnumerator IE_StartAnim(){
		float _tempTime = 0.0f;
		int _spriteCount = 0;

		while (_spriteCount < skillValue) {
			while (_tempTime < moveTime) {
				_tempTime += Time.deltaTime;
				yield return null;
			}
			thisImage.sprite = Sprites [_spriteCount++];
			_tempTime = 0.0f;
		}
	}

	public void Reset(){
		thisImage.sprite = Sprites [0];
	}
}
