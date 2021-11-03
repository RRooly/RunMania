using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 125f;
    public static MobileInput Instance { set; get; }
    private bool tap, swipeLeft, swipeRight;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private Animator animator;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    void Awake()
    {

        Instance = this;

    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Reset all the booleans
        tap = swipeLeft = swipeRight = false;

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Did we cross the deadzone ?
        if (swipeDelta.magnitude > DEADZONE)
        {

            //Which direction ?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                //Left or right
                if (x < 0)
                {
                    swipeLeft = true;
                    

                }
                else
                {
                    swipeRight = true;
                   

                }
            }
            Reset();
        }
    }

    void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        animator.SetBool("swipeLeft", false);
        animator.SetBool("swipeRight", false);

    }
}
