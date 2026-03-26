using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool isJumping = false;
    void Start()
    {
    }

    void Update()
    {
        var key = Keyboard.current;

        if (key.leftArrowKey.wasPressedThisFrame)
        {
            if (isJumping)
            {
                Debug.Log("공중에서는 점프할 수 없습니다!");
            }
            else
            {
                isJumping = true;
                Debug.Log("왼쪽으로 점프!");
            }
        }

        if (key.rightArrowKey.wasPressedThisFrame)
        {
            if (isJumping)
            {
                Debug.Log("공중에서는 점프할 수 없습니다!");
            }
            else
            {
                isJumping = true;
                Debug.Log("오른쪽으로 점프!");
            }
        }

        if (key.upArrowKey.wasPressedThisFrame)
        {
            if (isJumping)
            {
                Debug.Log("공중에서는 점프할 수 없습니다!");
            }
            else
            {
                isJumping = true;
                Debug.Log("위로 점프!");
            }
        }

        if (key.spaceKey.wasPressedThisFrame)
        {
            isJumping = false;
            Debug.Log("착지!");
        }
    }
}