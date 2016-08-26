using UnityEngine;
using System.Collections;

public class HowToPlayController : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPressPlay()
    {
        Application.LoadLevel("MazeScene");
    }
}
