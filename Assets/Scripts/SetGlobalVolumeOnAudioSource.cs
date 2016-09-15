using UnityEngine;
using System.Collections;

public class SetGlobalVolumeOnAudioSource : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        Debug.Log("on enable! " + name);
        GetComponent<AudioSource>().volume = AudioManagerSingleton.GetInstance().GetGlobalVolume();
    }
}
