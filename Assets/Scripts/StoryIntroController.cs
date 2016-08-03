using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryIntroController : MonoBehaviour
{
    public Text textHeader;
    public Text textFooter;
    public Text textBody1;
    public Text textBody2;

	// Use this for initialization
	void Start ()
    {
        textHeader.canvasRenderer.SetAlpha(0f);
        textFooter.canvasRenderer.SetAlpha(0f);
        textBody1.canvasRenderer.SetAlpha(0f);
        textBody2.canvasRenderer.SetAlpha(0f);

        StartCoroutine(DisplayStoryText());
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator DisplayStoryText()
    {
        yield return new WaitForSeconds(2f);

        textHeader.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(2f);

        textBody1.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(3f);

        textBody2.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(6f);

        textHeader.CrossFadeAlpha(0f, 2f, false);
        textBody1.CrossFadeAlpha(0f, 2f, false);
        textBody2.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(3f);

        textBody1.text = "Your mission is to get Elf back through the maze.";
        textBody2.text = "Along the way, you'll face doors you can't fit through, characters who won't let you pass, traps set by others, and diminishing health.";

        textBody1.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(4f);

        textBody2.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(7f);

        textBody1.CrossFadeAlpha(0f, 2f, false);
        textBody2.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(3f);

        textBody1.text = "You'll have the help of other characters that you befriend throughout the game.";
        textBody2.text = "But take caution...Some might be a friendly face hiding evil, and others might be a friend wearing an evil face.";

        textBody1.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(3f);

        textBody2.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(6f);

        textBody1.CrossFadeAlpha(0f, 2f, false);
        textBody2.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(3f);

        textBody1.text = "Elf needs you to see past stereotypes and think critically to get back into place.";
        textBody2.text = "The fate of Elf, and all the characters of the book, rests with you.";

        textBody1.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(6f);

        textBody2.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(5f);

        textFooter.CrossFadeAlpha(1f, 2f, false);

        yield return new WaitForSeconds(2f);

        textBody1.CrossFadeAlpha(0f, 2f, false);
        textBody2.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(3f);

        textFooter.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(3f);

        StopCoroutine(DisplayStoryText());
        Application.LoadLevel("MazeScene");
    }
}