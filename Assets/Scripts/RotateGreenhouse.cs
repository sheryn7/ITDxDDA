using UnityEngine;

public class RotateGreenhouse : MonoBehaviour
{
    public float rotationSpeed = 0.2f;

    private Vector2 lastPosition;
    private bool isDragging = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                lastPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                float deltaX = touch.position.x - lastPosition.x;

                transform.Rotate(
                    Vector3.up,
                    -deltaX * rotationSpeed,
                    Space.Self
                );

                lastPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended ||
                     touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }
}