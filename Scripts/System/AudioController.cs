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
		backgroundMusic.Play ();
	}

	public static void StopBackgroundMusic(){
		AudioController.instance.M_StopBackgroundMusic();
	}

	public void M_StopBackgroundMusic(){
		backgroundMusic.Stop ();
	}

	public static void PlaySoundEffect(SoundEffectType p_type){
		AudioController.instance.M_PlaySoundEffect (p_type);
	}

	public void M_PlaySoundEffect(SoundEffectType p_type){
		soundEffect.clip = Resources.Load ("Sounds/" + p_type.ToString ()) as AudioClip;
		soundEffect.Play ();
	}
}
