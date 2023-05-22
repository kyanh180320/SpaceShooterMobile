using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cameraMain;
    void Start()
    {
        cameraMain = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Touch myTouch = Touch.activeTouches[0];
        Vector3 touchPos = myTouch.screenPosition;
        touchPos = cameraMain.ScreenToWorldPoint(touchPos);

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
