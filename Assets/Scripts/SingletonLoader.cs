using UnityEngine;
using System.Collections;

public class SingletonLoader : MonoBehaviour
{
    public GameObject AudioManagerObjectPrefab;

	void Awake ()
    {
        if (AudioManagerSingleton.GetInstance() == null) //Check if an AudioManager has already been assigned to static variable GameManager.instance or if it's still null
        {
            Instantiate(AudioManagerObjectPrefab);  // Instantiate AudioManager prefab
        }              
	}
}