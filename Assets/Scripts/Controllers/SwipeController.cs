using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static Side side = Side.Right;
    public static bool isNeedToMove = false;
    public static bool tap = false;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void FixedUpdate() {
        tap = isNeedToMove =false;

        #region desktop
        if (Input.GetMouseButtonDown(0)) {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0)) {
            isDraging = false;
            Reset();
        }
        #endregion

        #region mobile
        if (Input.touches.Length > 0) {
            if (Input.touches[0].phase == TouchPhase.Began) {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        swipeDelta = Vector2.zero;
        if (isDraging){
            if (Input.touches.Length < 0) {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0)) {
                swipeDelta = (Vector2) Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 100) {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y)) {
                if (x < 0) {
                    side = Side.Left;
                    isNeedToMove = true;
                }
                else {
                    side = Side.Right;
                    isNeedToMove = true;
                }
            }
            Debug.Log("Side: "+side);
            Reset();
        }
    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}