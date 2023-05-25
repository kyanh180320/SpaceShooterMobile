using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cameraMain;
    private Vector3 offset;
    private float maxLeft, maxRight, maxDown, maxUp;
    void Start()
    {
        cameraMain = Camera.main;
        offset = transform.position;

        maxLeft = cameraMain.ViewportToWorldPoint(new Vector3(0.2f, 0, 0)).x;
        maxRight = cameraMain.ViewportToWorldPoint(new Vector3(0.8f, 0, 0)).x;
        maxDown = cameraMain.ViewportToWorldPoint(new Vector3(0, 0.1f, 0)).y;
        maxUp = cameraMain.ViewportToWorldPoint(new Vector3(0, 0.9f, 0)).y;

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.fingers[0].isActive) // check has fingers[0]
        {
            Touch myTouch = Touch.activeTouches[0]; //get all infor of fingers[0]
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = cameraMain.ScreenToWorldPoint(touchPos);
            //transform.position = new Vector3(touchPos.x, touchPos.y, 0);
            if (myTouch.phase == TouchPhase.Began)
            {
                offset = transform.position - touchPos;
            }
            else if (myTouch.phase == TouchPhase.Moved)
            {
                transform.position  = new Vector3(touchPos.x + offset.x, touchPos.y+offset.y, 0);
            }
            else if(myTouch.phase == TouchPhase.Stationary)
            {
                transform.position = new Vector3(touchPos.x + offset.x, touchPos.y + offset.y, 0);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp),0);
        }
        

    }
    protected void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    protected void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
}
