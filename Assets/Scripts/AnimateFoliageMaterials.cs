using UnityEngine;
using System.Collections;

public class AnimateFoliageMaterials : MonoBehaviour
{
    Material[] foliageMats;
    public GameObject targetMesh;
    public Vector4 waveAndDistValsFerns;
    public Vector4 waveAndDistValsFirBranches;

	// Use this for initialization
	void Start ()
    {
        foliageMats = targetMesh.GetComponent<Renderer>().sharedMaterials;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector4 _test = new Vector4(Random.Range(0,20),Random.Range(0,20), Random.Range(0,20), Random.Range(0,20));
        foliageMats[1].SetVector("_WaveAndDistance", waveAndDistValsFerns);
        foliageMats[3].SetVector("_WaveAndDistance", waveAndDistValsFirBranches);
	}
}
