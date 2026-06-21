using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;




    public override void Interact(PlayerController playerController)
    {
        if (!HasKitchenObject())
        {
            if (playerController.HasKitchenObject())
            {
                playerController.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                // Player not carrying 
            }
        }
        else
        {
            if (playerController.HasKitchenObject() && kitchenObjectSO != null)
            {
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }

    }
}