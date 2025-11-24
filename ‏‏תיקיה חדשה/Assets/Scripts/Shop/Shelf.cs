using UnityEngine;
using UnityEngine.InputSystem; 

public class Shelf : MonoBehaviour
{
    public GameObject productPrefab; 

    private bool playerInRange = false;
    private PlayerInventory playerInventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = collision.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!playerInventory.isHolding)
            {
                GameObject newProduct = Instantiate(productPrefab);
                playerInventory.PickupProduct(newProduct);
            }
        }
    }
}
