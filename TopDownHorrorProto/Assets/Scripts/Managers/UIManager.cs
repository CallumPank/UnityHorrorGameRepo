using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


sealed class UIManager : MonoBehaviour
{
	#region Singleton
	public static UIManager instance;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void OnRuntimeMethodLoad()
	{
		var _instance = FindObjectOfType<UIManager>();

		//if (_instance == null)
		//	_instance = new GameObject("UIManager").AddComponent<UIManager>();

		DontDestroyOnLoad(_instance);

		instance = _instance;
	}
	#endregion

	public GameObject interactNotifier;
	public Text healthText;

	// Use this for initialization
	void Start()
	{
		HideInteractNotifier();
		UpdateHealthUI();
	}

	public void ShowInteractNotifier(string interact, string objName)
	{
		interactNotifier.GetComponent<Text>().text = "Press E to " + interact + " " + objName;
		interactNotifier.SetActive(true);
	}

	public void HideInteractNotifier()
	{
		interactNotifier.SetActive(false);
	}

	public void UpdateHealthUI()
	{
		healthText.text = "Health: " + GameManager.instance.playerHealth;
	}
}
