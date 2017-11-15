using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOVScript : MonoBehaviour
{
	[Header("FOV Sizes")]
	[SerializeField]
	Vector3 noTorchFOVSize;
	[SerializeField]
	Vector3 torchFOVSize;
	[Header("Cone and torch ref")]
	[SerializeField]
	GameObject cone;
	[SerializeField]
	GameObject torch;

	[SerializeField]
	bool usingTorch;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (GameManager.instance.hasTorch)
		{
			if (Input.GetKeyDown(KeyCode.F))
			{
				usingTorch = !usingTorch;
			}
		} else
		{
			torch.SetActive(false);
			cone.transform.localScale = noTorchFOVSize;
		}

		if (usingTorch)
		{
			torch.SetActive(true);
			cone.transform.localScale = torchFOVSize;
		}
		else
		{
			torch.SetActive(false);
			cone.transform.localScale = noTorchFOVSize;
		}
	}
}
