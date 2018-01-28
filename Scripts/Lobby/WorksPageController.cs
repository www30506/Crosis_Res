using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WorksPageController : Page_Base {
	[System.Serializable]
	public class ButtonData{
		public string name;
		public string videoName;
		[HideInInspector]public Text text;
	}

	private WebGLMovieTexture movieTexture;
	[SerializeField]private RawImage closeMovie;
	[SerializeField]private GameObject moviePlane;
	[SerializeField]private GameObject closeMovieTipObj;
	[SerializeField]private GameObject LoadingMoiveTipObj;
	[SerializeField]private ButtonData[] buttonsData;
	private bool isPlayingMovie = false;
	IEnumerator contrin;

	void Awake(){		
	}

	void Start () {
		InitBtns ();
	}

	private void InitBtns(){
		for (int i = 0; i < buttonsData.Length; i++) {
			buttonsData [i].text = this.transform.Find ("BtnGroups").GetChild (i).transform.Find("Text").GetComponent<Text>();
			buttonsData [i].text.text = buttonsData [i].name;
		}
	}

	void OnDisable(){
	}

	protected override void OnClose(){
		#if !UNITY_EDITOR
		StopMovie ();
		#endif
	}

	protected override void OnOpen(){
		moviePlane.gameObject.SetActive (false);
		closeMovie.gameObject.SetActive (false);
		LoadingMoiveTipObj.SetActive (false);
		#if !UNITY_EDITOR
		if(movieTexture == null){
			moviePlane.GetComponent<MeshRenderer>().material = new Material (Shader.Find("Diffuse"));
		}
		#endif
	}

	void Update () {
		if (clickTime >= 0) {
			clickTime -= Time.deltaTime;
			if (clickTime <= 0) {
				closeMovieTipObj.SetActive (false);
			}
		}

		if (isPlayingMovie) {			
			movieTexture.Update();
		}
	}

	public void PlayVideo(int p_btnNumber){
		#if !UNITY_EDITOR
		if (isPlayingMovie) {
			return;
		}
		if (movieTexture != null) {
			movieTexture = null;
		}
		if (moviePlane.GetComponent<MeshRenderer> ().material != null) {
			Destroy (moviePlane.GetComponent<MeshRenderer> ().material);
		}
		movieTexture = new WebGLMovieTexture("StreamingAssets/" + buttonsData[p_btnNumber].videoName + ".mp4");
		movieTexture.Seek (0);
		moviePlane.GetComponent<MeshRenderer>().material = new Material (Shader.Find("Diffuse"));
		moviePlane.GetComponent<MeshRenderer>().material.mainTexture = movieTexture;
		contrin = IE_OnVdartsMovie ();
		StartCoroutine (contrin);
		#endif
	}

	public void OnVdartsMovieBtn(){
		#if !UNITY_EDITOR
		if (isPlayingMovie) {
			return;
		}

		contrin = IE_OnVdartsMovie ();
		StartCoroutine (contrin);
		#endif
	}

	IEnumerator IE_OnVdartsMovie(){
		isPlayingMovie = true;
		clickTime = 0;
		LoadingMoiveTipObj.SetActive (true);
		while (movieTexture.isReady == false) {
			yield return null;
		}
		LoadingMoiveTipObj.SetActive (false);
		closeMovie.gameObject.SetActive (true);
		moviePlane.gameObject.SetActive (true);

		AudioController.StopBackgroundMusic ();

		movieTexture.Seek(0);
		movieTexture.Play ();

		while (movieTexture.time < movieTexture.duration) {
			yield return null;
		}
		StopMovie ();
		AudioController.StartBackgroundMusic ();
		isPlayingMovie = false;
	}

	private float clickTime ;
	private float clickMaxTime = 1.5f;

	public void CloseVdartsMovieBtn(){
		if (clickTime <= 0) {
			clickTime = clickMaxTime;
			closeMovieTipObj.SetActive (true);
		}
		else {
			if (contrin != null) {
				StopCoroutine (contrin);
			}

			closeMovieTipObj.SetActive (false);
			StopMovie ();
			AudioController.StartBackgroundMusic ();
			isPlayingMovie = false;
		}
	}


	private void StopMovie(){
		if (movieTexture != null) {
			movieTexture.Pause ();
			movieTexture.Seek (0);
		}
		closeMovie.gameObject.SetActive (false);
		moviePlane.gameObject.SetActive (false);
	}
}
