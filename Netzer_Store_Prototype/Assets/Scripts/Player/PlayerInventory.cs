using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool isHolding = false;
    public GameObject heldProduct;

    public void PickupProduct(GameObject product)
    {
        isHolding = true;
        heldProduct = product;

        product.transform.SetParent(transform);
        product.transform.localPosition = new Vector3(0.3f, 0.3f, 0f);
    }

    public GameObject DropProduct()
    {
        isHolding = false;
        GameObject temp = heldProduct;
        heldProduct = null;
        return temp;
    }
}
