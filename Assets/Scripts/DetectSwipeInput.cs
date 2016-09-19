using UnityEngine;
using System.Collections;

public class DetectSwipeInput : MonoBehaviour
{
    public float minSwipeDist = 14.0f;
    public float maxSwipeTime = 0.5f;
    bool couldBeSwipe;

    float swipeStartTime;
    Vector2 startPos;

    Player player;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        StartCoroutine(checkHorizontalSwipes());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator checkHorizontalSwipes() //Coroutine, wich gets Started in "Start()" and runs over the whole game to check for swipes
    {
        while (true)
        { //Loop. Otherwise we wouldnt check continoulsy ;-)
            foreach (Touch touch in Input.touches)
            { //For every touch in the Input.touches - array...

                switch (touch.phase)
                {
                    case TouchPhase.Began: //The finger first touched the screen --> It could be(come) a swipe
                        couldBeSwipe = true;

                        startPos = touch.position;  //Position where the touch started
                        swipeStartTime = Time.time; //The time it started
                        break;

                    case TouchPhase.Stationary: //Is the touch stationary? --> No swipe then!
                        couldBeSwipe = false;
                        break;
                }
                float swipeTime = Time.time - swipeStartTime; //Time the touch stayed at the screen till now.
                float swipeDist = Mathf.Abs(touch.position.x - startPos.x); //Swipedistance


                if (couldBeSwipe && swipeTime < maxSwipeTime && swipeDist > minSwipeDist)
                {
                    // It's a swiiiiiiiiiiiipe!
                    couldBeSwipe = false; //<-- Otherwise this part would be called over and over again.

                    if (Mathf.Sign(touch.position.x - startPos.x) == 1f)
                    { //Swipe-direction, either 1 or -1.
                        player.TurnLeft();
                    }
                    else
                    {
                        player.TurnRight(); 
                    }
                }
            }
            yield return null;
        }
    }
}