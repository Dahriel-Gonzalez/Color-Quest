using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTouch : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    //testTouch lastTouch;

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            //lastTouch = Input.touches[Input.touches.Length - 1];
            if (Input.touchCount > 0 && Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Began)
            {
                startTouchPos = Input.GetTouch(Input.touches.Length - 1).position;
                print(startTouchPos);
            }
            if (Input.touchCount > 0 && Input.GetTouch(Input.touches.Length - 1).phase == TouchPhase.Ended)
            {
                endTouchPos = Input.GetTouch(Input.touches.Length - 1).position;
                print(endTouchPos);
                if ((Mathf.Abs(startTouchPos.x - endTouchPos.x) > 200) || (Mathf.Abs(startTouchPos.y - endTouchPos.y) > 200))
                {
                    if (Mathf.Abs(startTouchPos.x - endTouchPos.x) > Mathf.Abs(startTouchPos.y - endTouchPos.y))
                    {
                        if (endTouchPos.x < startTouchPos.x)
                        {
                            print("dash left");
                        }
                        if (endTouchPos.x > startTouchPos.x)
                        {
                            print("dash right");
                        }
                    }
                    else
                    {
                        if (endTouchPos.y < startTouchPos.y)
                        {
                            print("dash down");
                        }
                        if (endTouchPos.y > startTouchPos.y)
                        {
                            print("dash up");
                        }
                    }
                }
            }
        }
        
    }

}
