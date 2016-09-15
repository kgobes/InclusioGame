using UnityEngine;
using System.Collections;

public class ToggleRenderCams : MonoBehaviour
{
    public GameObject camContainer;

	void Update ()
    {
       camContainer.SetActive(GetComponent<CanvasGroup>().alpha > 0.1f);
	}
}