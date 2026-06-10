using UnityEngine;

public class ContainerCounter : MonoBehaviour
{
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
}
