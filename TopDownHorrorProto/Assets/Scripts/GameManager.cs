using System.Collections;
using System.Collections.Generic;
using UnityEngine;

sealed class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager instance;

    [RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnRuntimeMethodLoad () {
        var _instance = FindObjectOfType<GameManager> ();

        if (_instance == null)
            _instance = new GameObject ("GameManager").AddComponent<GameManager> ();

        DontDestroyOnLoad (_instance);

        instance = _instance;
    }
    #endregion

    public GameObject player;

     void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
    }
}
