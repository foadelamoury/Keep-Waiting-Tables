using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;

    private KitchenObjects kitchenObject;

    public override void Interact(PlayerController playerController)
    {
        if (!playerController.HasKitchenObject())
        {
            if (kitchenObjectSO != null)
            {
                Transform kitchenObjectClone = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
                kitchenObjectClone.GetComponent<KitchenObjects>().SetKitchenObjectParent(playerController);
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
