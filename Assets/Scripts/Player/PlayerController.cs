using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;

    bool isWalking;

    private void Start()
    {

    }
    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        PlayerInput(inputVector);
    }

    private void PlayerInput(Vector2 inputVector)
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
        // Normalize the input vector to ensure consistent movement speed in all directions (especially diagonally)
        inputVector.Normalize(); //or inputVector = inputVector.normalized;
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        transform.position += moveDir * Time.deltaTime * movementSpeed;
        
        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }
    public bool IsWalking()
    {
        return isWalking;
    }
}
