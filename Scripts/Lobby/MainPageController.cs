using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageController : Page_Base {
	[SerializeField]private GameObject[] btns;
	private UTweenPosition[] fadeInoTween;
	private UTweenPosition[] fadeOutTween;
	[SerializeField]private CanvasGroup circleCanvasGroup;
	[SerializeField]private AnimationCurve curve;

	void Awake(){
		fadeInoTween = new UTweenPosition[btns.Length];
		fadeOutTween = new UTweenPosition[btns.Length];
		for(int i =0 ; i< btns.Length; i++){
			UTweenPosition[] _tweens = btns[i].GetComponents<UTweenPosition>();
			fadeInoTween [i] = _tweens [0];
			fadeOutTween [i] = _tweens [1];
		}	
	}

	void Start () {
		circleCanvasGroup.alpha = 0;
	}

	protected override void OnClose(){
	}

	protected override void OnOpen(){
	}

	protected override IEnumerator IE_ClosePageAnim(){
		yield return StartCoroutine (CircleFadeOutAnim());
		FadeOutAnim ();
		yield return new WaitForSeconds(fadeInoTween[1].Duration);
	}

	protected override IEnumerator IE_OpenPageAnim(){
		FadeInAnim ();
		yield return new WaitForSeconds(fadeInoTween[0].Duration );
		yield return StartCoroutine (CircleFadeInAnim());
	}

	void Update () {
		
	}

	public void OnExperiencePageBtn(){
		#if Clog
		print ("----\t開啟經歷頁面\t----");
		#endif

		PageManerger.ChangePage (PageType.ExperiencePage);
		AudioController.PlaySoundEffect (SoundEffectType.ButtonClick);
	}

	public void OnSkillPageBtn(){
		#if Clog
		print ("----\t開啟技能頁面\t----");
		#endif

		PageManerger.ChangePage (PageType.SkillPage);
		AudioController.PlaySoundEffect (SoundEffectType.ButtonClick);
	}

	public void OnPersonalityPageBtn(){
		#if Clog
		print ("----\t開起人格特質頁面\t----");
		#endif

//		PopMessage.ConfirmMessage ("錯誤", "功能未開放");
//		AudioController.PlayMusic (SoundEffectType.ButtonClick);
//		PageManerger.ChangePage (PageType.PersonalityPage);
	}

	public void WorksPageBtn(){
		#if Clog
		print ("----\t開啟作品頁面\t----");
		#endif

		PageManerger.ChangePage (PageType.WorksPage);
		AudioController.PlaySoundEffect (SoundEffectType.ButtonClick);
	}

	private void FadeInAnim(){
		for (int i = 0; i < fadeInoTween.Length; i++) {
			fadeInoTween [i].ReSetToStart ();
			fadeInoTween [i].enabled = true;
		}
	}

	private void FadeOutAnim(){
		for (int i = 0; i < fadeInoTween.Length; i++) {
			fadeOutTween [i].ReSetToStart ();
			fadeOutTween [i].enabled = true;
		}
	}

	IEnumerator CircleFadeInAnim(){
		float _tempTime = 0.0f;
		while (_tempTime < 1.0f) {
			_tempTime += Time.deltaTime;
			circleCanvasGroup.alpha = curve.Evaluate(_tempTime / 1.0f);
			yield return null;
		}
		circleCanvasGroup.alpha = 1;
	}

	IEnumerator CircleFadeOutAnim(){
		float _tempTime = 0.0f;
		while (_tempTime < 1.0f) {
			_tempTime += Time.deltaTime;
			circleCanvasGroup.alpha = 1 - (_tempTime / 1.0f);
			yield return null;
		}
		circleCanvasGroup.alpha = 0;
	}
}
