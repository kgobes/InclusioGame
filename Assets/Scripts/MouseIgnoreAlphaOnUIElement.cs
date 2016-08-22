using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MouseIgnoreAlphaOnUIElement : MonoBehaviour
{
    Image button;

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
    }
}