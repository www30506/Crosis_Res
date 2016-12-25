using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
	public static AudioController instance;
	AudioSource backgroundMusic;
	AudioSource soundEffect;

	void Awake(){
		instance = this;
		backgroundMusic = GameObject.Find ("Main Camera/Music").GetComponent<AudioSource>();
		soundEffect = GameObject.Find ("Main Camera/SoundEffect").GetComponent<AudioSource>();
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	public static void StartBackgroundMusic(){
		AudioController.instance.M_StartBackgroundMusic ();
	}

	public void M_StartBackgroundMusic(){
		backgroundMusic.volume = 0.4f;
	}

	public static void StopBackgroundMusic(){
		AudioController.instance.M_StopBackgroundMusic();
	}

	public void M_StopBackgroundMusic(){
		backgroundMusic.volume = 0;
	}

	public static void PlayMusic(SoundEffectType p_type){
		AudioController.instance.M_PlayMusic (p_type);
	}

	public void M_PlayMusic(SoundEffectType p_type){
		soundEffect.clip = Resources.Load ("Sounds/" + p_type.ToString ()) as AudioClip;
		soundEffect.Play ();
	}
}
