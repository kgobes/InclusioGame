using UnityEngine;
using System.Collections;

public class SetMusic : MonoBehaviour
{
    public MusicType musicToSet;

	void Start ()
    {
        AudioManagerSingleton.GetInstance().SetMusic(musicToSet);
	}
}