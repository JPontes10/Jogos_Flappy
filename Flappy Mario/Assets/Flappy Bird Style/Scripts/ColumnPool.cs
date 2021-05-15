using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ColumnPool : MonoBehaviour 
{
	public GameObject columnPrefab;									//The column game object.
	public int columnPoolSize = 5;									//How many columns to keep on standby.
	public float spawnRate = 3f;									//How quickly columns spawn.
	public float columnMin = -1f;									//Minimum y value of the column position.
	public float columnMax = 3.5f;									//Maximum y value of the column position.

	private GameObject[] columns;									//Collection of pooled columns.
	private int currentColumn = 0;									//Index of the current column in the collection.

	private Vector2 objectPoolPosition = new Vector2 (-15,-25);		//A holding position for our unused columns offscreen.
	private float spawnXPosition = 10f;

	private float timeSinceLastSpawned;

	private int lastNum;



	void Start()
	{
		timeSinceLastSpawned = 0f;
		
		columns = new GameObject[columnPoolSize];
		 
		for(int i = 0; i < columnPoolSize; i++)
		{
			
			columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}



	void Update()
	{
		timeSinceLastSpawned += Time.deltaTime;

		if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate) 
		{	
			timeSinceLastSpawned = 0f;

			float spawnYPosition = Random.Range(columnMin, columnMax);
			columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn ++;

			if (currentColumn >= columnPoolSize) 
			{
				currentColumn = 0;
			}

			if(GameControl.instance.score < 100  && (GameControl.instance.score % 10 == 0)){
				RandomPowerUp(GameControl.instance.score);
			}
		}

		if(Input.GetKeyDown (KeyCode.Escape)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
		}
	}

	void RandomPowerUp(int score){
		//float auxSpawnRate = spawnRate;
		//float auxScrollingSpeed = GameControl.instance.scrollSpeed;
		int num = GetRandomNum(lastNum);
		switch(num){
			case 1: SpeedPowerUp() ;
			break;
			case 2: ;
			break;
			case 3: ;
			break;
			case 4: ;
			break;
		}
	}

	int GetRandomNum(int lastNum){
        int randNumber = 0;
		do{
			lastNum = randNumber;
			Random rnd = new Random();
			randNumber = Random.Range(1, 2);
		}while(randNumber == lastNum);
		return randNumber;
	}


	void SpeedPowerUp(){
		//GameControl.instance.scrollSpeed -= 5f; 
		//Debug.Log("scrollSpeed = " + GameControl.instance.scrollSpeed);
		Debug.Log(spawnRate);
		if(spawnRate > 2f){
			spawnRate = spawnRate - 0.5f;
		}else if(spawnRate > 1f){
			spawnRate = spawnRate - 0.1f;
		}
		Debug.Log(spawnRate);
	}

}