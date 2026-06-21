using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] KitchenObjectSO kitchenObjectSO;


    public override void Interact(PlayerController playerController)
    {
        if (!playerController.HasKitchenObject())
        {
            Transform kitchenObjectClone = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectClone.GetComponent<KitchenObjects>().SetKitchenObjectParent(playerController);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }

}
