using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;
    [SerializeField] ClearCounter secondClearCounter;
    [SerializeField] bool testing;

    // Change this variable type to match what it's holding
    private KitchenObjects kitchenObject;

    // Update this method signature and implementation
    public void Interact(PlayerController playerController) 
    {
        if (!HasKitchenObject()) 
        {
            if (playerController.HasKitchenObject()) 
            {
                playerController.GetKitchenObject().SetKitchenObjectParent(this);
            } 
            else 
            {
                if (kitchenObjectSO != null) 
                {
                    Transform kitchenObjectClone = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
                    kitchenObjectClone.GetComponent<KitchenObjects>().SetKitchenObjectParent(this);
                }
            }
        } 
        else 
        {
            if (!playerController.HasKitchenObject()) 
            {
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

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