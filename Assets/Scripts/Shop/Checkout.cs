using UnityEngine;
using UnityEngine.InputSystem;

public class Checkout : MonoBehaviour
{
    private bool playerInRange = false;
    private bool customerInRange = false;
    private PlayerInventory playerInventory;
    private Customer currentCustomer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            playerInventory = collision.GetComponent<PlayerInventory>();
        }

        Customer c = collision.GetComponent<Customer>();
        if (c != null)
        {
            Debug.Log("CUSTOMER ENTER CHECKOUT!");
            customerInRange = true;
            currentCustomer = c;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;

        if (collision.GetComponent<Customer>() != null)
        {
            customerInRange = false;
            currentCustomer = null;
        }
    }

    private void Update()
    {
        if (playerInRange && customerInRange && playerInventory != null && playerInventory.isHolding && Keyboard.current.eKey.wasPressedThisFrame)
        {
            GameObject product = playerInventory.DropProduct();
            currentCustomer.ReceiveProduct(product);
            GameManager.Instance.AddMoney(20);
            FindObjectOfType<CustomerManager>().SpawnNextCustomer();
        }
    }
}
