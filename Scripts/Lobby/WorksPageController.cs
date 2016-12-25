using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class WorksPageController : Page_Base {
	private WebGLMovieTexture movieTexture;
	[SerializeField]private RawImage closeMovie;
	[SerializeField]private GameObject moviePlane;
	[SerializeField]private GameObject closeMovieTipObj;
	private bool isPlayingMovie = false;
	IEnumerator contrin;

	void Awake(){
		
	}

	void Start () {
		#if !UNITY_EDITOR
		movieTexture = new WebGLMovieTexture("StreamingAssets/VdartsMovie.mp4");
		movieTexture.Seek (0);
		moviePlane.GetComponent<MeshRenderer>().material = new Material (Shader.Find("Diffuse"));
		moviePlane.GetComponent<MeshRenderer>().material.mainTexture = movieTexture;
		#endif
	}

	void OnDisable(){
		#if !UNITY_EDITOR
		StopMovie ();
		#endif
	}

	protected override void OnClose(){
	}

	protected override void OnOpen(){
		moviePlane.gameObject.SetActive (false);
		closeMovie.gameObject.SetActive (false);
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
		movieTexture.Pause ();
		movieTexture.Seek(0);
		closeMovie.gameObject.SetActive (false);
		moviePlane.gameObject.SetActive (false);
	}
}
