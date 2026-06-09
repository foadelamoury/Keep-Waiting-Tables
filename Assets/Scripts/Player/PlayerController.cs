using System;
using UnityEngine;

public class PlayerController : MonoBehaviour , IKitchenObjectParent
{
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;

    public static PlayerController Instance { get; private set; }

    [SerializeField] Transform kitchenObjectHoldPoint;
    
    KitchenObjects kitchenObject;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;             
        }

        Instance = this;
        
    }

    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] GameInput gameInput;
    [SerializeField] LayerMask countersLayerMask;


    bool isWalking;

    Vector3 lastInteractDir; // lastInteractDirection 

    ClearCounter selectedCounter;

    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void Update()
    {

        HandleMovement();
        HandleInteractions();
    }


    public bool IsWalking()
    {
        return isWalking;
    }

    void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {

                // Has ClearCounter
                if (clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
                }



            }
            else
            {
                SetSelectedCounter(null);
            }

        }
        else
        {
            SetSelectedCounter(null);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = movementSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            // can't move towards moveDir

            //Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Can't move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    // Can move only on the Z
                    moveDir = moveDirZ;
                }
                else
                {
                    // Can't move on any direction
                }

            }
        }

        if (canMove) { transform.position += moveDir * moveDistance; }

        isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
    }

    void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = this.selectedCounter });
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObject = kitchenObject;  }

    public KitchenObjects GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
