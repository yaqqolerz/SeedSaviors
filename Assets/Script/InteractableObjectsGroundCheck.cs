using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectsGroundCheck : MonoBehaviour
{
    [SerializeField] private InteractableObject LeftTrigger;
    [SerializeField] private InteractableObject RightTrigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            LeftTrigger.isTouchingGround = true;
            RightTrigger.isTouchingGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            LeftTrigger.isTouchingGround = false;
            RightTrigger.isTouchingGround = false;
        }
    }
}
