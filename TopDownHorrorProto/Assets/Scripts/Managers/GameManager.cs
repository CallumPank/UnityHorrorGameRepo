using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

sealed class GameManager : MonoBehaviour
{
	#region Singleton
	public static GameManager instance;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void OnRuntimeMethodLoad()
	{
		var _instance = FindObjectOfType<GameManager>();

		//if (_instance == null)
		//	_instance = new GameObject("GameManager").AddComponent<GameManager>();

		DontDestroyOnLoad(_instance);

		instance = _instance;
	}
	#endregion

	public GameObject player;
	public float playerHealth;
	public float maxPlayerHealth;
	public bool hasTorch;
    public float playerFear;
	public bool enemyDetected;

	void Awake()
	{
		playerHealth = maxPlayerHealth;
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform.root.gameObject;
	}

	void Update()
	{
		if (playerHealth <= 0f)
		{
			Debug.Log("Player has died");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		playerFear = Mathf.Clamp(playerFear, 0f, 100f);
	}

	public void DamagePlayer(float damage)
	{
		playerHealth -= damage;
		playerHealth = Mathf.Clamp(playerHealth, 0f, maxPlayerHealth);
		UIManager.instance.UpdateHealthUI();
		Debug.Log(damage + " damage dealt to player");
	}

	public void HealPlayer(float healthToAdd)
	{
		playerHealth += healthToAdd;
		playerHealth = Mathf.Clamp(playerHealth, 0f, maxPlayerHealth);
		UIManager.instance.UpdateHealthUI();
		Debug.Log(healthToAdd + " health added to player");
	}
}
