using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InheritParentAlpha : MonoBehaviour
{
    CanvasRenderer parent;
    CanvasRenderer canvasRenderer;

	// Use this for initialization
	void Start ()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();
        parent = transform.parent.GetComponent<CanvasRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        canvasRenderer.SetAlpha(parent.GetAlpha());
	}
}
