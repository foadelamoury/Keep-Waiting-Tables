using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerInputActions playerInputActions;
    

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interacting;
    }

    private void Interacting(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
        OnInteractAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        


        return PlayerInput(inputVector);

    }

    Vector2 PlayerInput(Vector2 inputVector)
    {

        // Normalize the input vector to ensure consistent movement speed in all directions (especially diagonally)
        //But now it  is in the new input system  processor //inputVector.Normalize(); or inputVector = inputVector.normalized;

        return inputVector;
    }

}
