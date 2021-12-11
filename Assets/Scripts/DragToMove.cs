using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToMove : MonoBehaviour
{
    private Touch touch;
    private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        speedModifier = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            // Get First Finger only
            touch = Input.GetTouch(0);

            // Finger Moving => Move Car
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y, transform.position.z + touch.deltaPosition.y * speedModifier);
                // Z * Y => Beaucase touch happen in screen and screen is 2d not have z axis.
            }
        }
    }
}
