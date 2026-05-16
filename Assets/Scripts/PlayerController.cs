using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        Vector2 inputVector = new Vector2(0,0);
       
        PlayerInput(inputVector);
    }

    private static void PlayerInput(Vector2 inputVector)
    {
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = 1;
        }
        inputVector.Normalize();
    }
}
