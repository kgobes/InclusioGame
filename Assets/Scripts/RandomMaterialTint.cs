using UnityEngine;
using System.Collections;

public class RandomMaterialTint : MonoBehaviour
{
    MaterialPropertyBlock block;

	// Use this for initialization
	void Start ()
    {
        block = new MaterialPropertyBlock();
        GetComponent<MeshRenderer>().GetPropertyBlock(block);
        Color _randColor = new Color(Random.value,Random.value,Random.value);
        block.SetVector("_Color", new Vector4(_randColor.r, _randColor.g, _randColor.b, 1));
        GetComponent<MeshRenderer>().SetPropertyBlock(block);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
