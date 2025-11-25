using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform spawnPoint;
    public Transform queuePoint;

    private int customersServed = 0;
    private int maxCustomers = 3;

    private bool waitingForCustomerToLeave = false;
    private bool activeCustomerExists = false;

    private void Start()
    {
        SpawnNextCustomer();
    }

    public void SpawnNextCustomer()
    {
        if (customersServed >= maxCustomers || waitingForCustomerToLeave || activeCustomerExists)
            return;

        GameObject newCust = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        Customer cust = newCust.GetComponent<Customer>();

        cust.SetTarget(queuePoint.position);
        activeCustomerExists = true;

        customersServed++;
    }

    public void NotifyCustomerServed()
    {
        waitingForCustomerToLeave = true;
    }

    public void CustomerLeft()
    {
        waitingForCustomerToLeave = false;
        activeCustomerExists = false;
        SpawnNextCustomer();
    }
}
