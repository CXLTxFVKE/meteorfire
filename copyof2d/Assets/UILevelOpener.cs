using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevelOpener : MonoBehaviour {

	public void LoadSceneOnClick(int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}
}

