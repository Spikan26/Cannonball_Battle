using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
	//Change la sc�ne
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	//Quitte le jeu
	public void Exit()
	{
		Application.Quit();
	}

}
