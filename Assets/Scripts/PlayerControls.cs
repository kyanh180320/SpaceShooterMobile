using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cameraMain;
    private Vector3 offset;
    void Start()
    {
        cameraMain = Camera.main;
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
            touchPos = cameraMain.ScreenToWorldPoint(touchPos);
            transform.position = new Vector3(touchPos.x, touchPos.y, 0);
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
