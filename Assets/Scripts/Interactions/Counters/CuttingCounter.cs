using UnityEngine;

public class CuttingCounter : BaseCounter
{

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
            if (playerController.HasKitchenObject())
            {
            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(playerController);
            }
        }
    }





}
