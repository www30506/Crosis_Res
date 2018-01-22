using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPageController : Page_Base {
	[SerializeField]private SkillItem[] skillItems;
	[System.Serializable]
	private class C_Skill{
		public int value;
		public string name;
	}
	[SerializeField]private C_Skill[] skillValue;

	void Awake(){
		skillItems = this.GetComponentsInChildren<SkillItem> ();
	}

	void Start () {
		
	}

	protected override void OnClose(){
		
	}

	protected override void OnOpen(){
		SkillBarReset ();
		SkillBarAnim ();
	}

	void Update () {
		
	}

	private void SkillBarReset(){
		for (int i = 0; i < skillItems.Length; i++) {
			skillItems [i].Reset();
		}
	}

	private void SkillBarAnim(){
		for (int i = 0; i < skillItems.Length; i++) {
			skillItems [i].SetDate (skillValue [i].value, skillValue [i].name);
			skillItems [i].StartAnim ();
		}
	}
}
