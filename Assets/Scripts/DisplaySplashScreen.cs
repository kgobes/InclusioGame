using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplaySplashScreen : MonoBehaviour
{
    public Image logo1;
    public Image logo2;

    public float fadeDurationSeconds = 1f;
    public float timeBetweenLogosSeconds = 1f;
    public float displayDurationSeconds = 2f;

	// Use this for initialization
	void Start ()
    {
        logo1.canvasRenderer.SetAlpha(0f);
        logo2.canvasRenderer.SetAlpha(0f);
        StartCoroutine(DisplayLogo1());
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    IEnumerator DisplayLogo1()
    {
        yield return new WaitForSeconds(timeBetweenLogosSeconds);

        logo1.CrossFadeAlpha(1f, fadeDurationSeconds, false);

        yield return new WaitForSeconds(displayDurationSeconds);

        logo1.CrossFadeAlpha(0f, fadeDurationSeconds, false);

        StartCoroutine(DisplayLogo2());
        StopCoroutine(DisplayLogo1());
    }

    IEnumerator DisplayLogo2()
    {
        yield return new WaitForSeconds(timeBetweenLogosSeconds);

        logo2.CrossFadeAlpha(1f, fadeDurationSeconds, false);

        yield return new WaitForSeconds(displayDurationSeconds);

        logo2.CrossFadeAlpha(0f, fadeDurationSeconds, false);

        yield return new WaitForSeconds(timeBetweenLogosSeconds);

        StopCoroutine(DisplayLogo2());

        Application.LoadLevel("StartScreen");
    }
}
