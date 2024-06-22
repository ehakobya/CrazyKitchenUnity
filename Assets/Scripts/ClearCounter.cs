using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform countertopPoint;

    private KitchenObject kitchenObject;

    public void Interact(Player player) {
        if (kitchenObject == null) {
            // spawn the object
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, countertopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else {
            // give the objct to the player
            kitchenObject.SetKitchenObjectParent(player);

        }
    }

    public Transform GetKitchenObjectFollowTransform() {
        return countertopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
