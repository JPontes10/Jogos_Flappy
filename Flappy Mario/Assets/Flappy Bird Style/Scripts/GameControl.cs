using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour 
{
	public static GameControl instance;			
	public Text scoreText;						
	public GameObject GameOvertext;				

	public int score = 0;						
	public bool gameOver = false;				
	public float scrollSpeed = -1.5f;

	private string speedDif;

	void Awake()
	{
		if (instance == null){
			instance = this;
		}
		else if(instance != this)
			Destroy (gameObject);

		speedDif = PlayerPrefs.GetString("scrollSpeed");
		if(string.Equals(speedDif,"True")){
			scrollSpeed = -6f;
		}else{
			scrollSpeed = -3f;
		}
		Debug.Log(scrollSpeed);	
	}

	void Update(){
		
		
		if (gameOver && Input.GetMouseButtonDown(0)) 
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void BirdScored(){
		if (gameOver){
			return;
		}		
		score++;
		scoreText.text = "Score: " + score.ToString();
	}

	public void BirdDied()
	{
		GameOvertext.SetActive (true);
		gameOver = true;
	}

	/*public void HardMode(){
		scrollSpeed = -5f;
	}*/
}
