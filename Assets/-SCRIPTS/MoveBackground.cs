using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBackground : MonoBehaviour
{
    public float movefactor;
    public InputActionReference moveAction;

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        if (moveInput.x != 0)
        {
            Vector2 pos = this.transform.position;
            pos.x += moveInput.x * movefactor * Time.deltaTime;
            this.transform.position = pos;
        }
    }
}