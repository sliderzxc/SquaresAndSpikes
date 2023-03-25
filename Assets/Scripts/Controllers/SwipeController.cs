using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static Side side = Side.Right;
    public static bool isNeedToMove = false;
    public static bool tap = false;

    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        tap = isNeedToMove = false;

        #region desktop
        if (Input.GetMouseButtonDown(0)) {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            isDragging = false;
            ResetSwipe();
        }
        #endregion

        #region mobile
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began) {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDragging = false;
                ResetSwipe();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDragging) {
            if (Input.touchCount > 0) {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0)) {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 100) {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y)) {
                side = x < 0 ? Side.Left : Side.Right;
                isNeedToMove = true;
            }
            Debug.Log("Side: " + side);
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }
}