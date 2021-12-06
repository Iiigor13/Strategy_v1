using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public void SceneLoading(int index)
	{
		SceneManager.LoadScene(index);
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
