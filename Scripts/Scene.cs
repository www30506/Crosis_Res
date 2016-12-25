using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene{
	public static void LoadScene(SceneName p_name){ 
		SceneManager.LoadScene(p_name.ToString(), LoadSceneMode.Single);
	}
}
