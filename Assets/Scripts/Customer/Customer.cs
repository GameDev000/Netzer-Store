using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 2f;
    private bool isServed = false;
    public void SetTarget(Vector3 pos)
    {
        targetPosition = pos;
    }

    private void Update()
    {
        if (!isServed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void ReceiveProduct(GameObject product)
    {
        isServed = true;

        product.transform.SetParent(transform);
        product.transform.localPosition = new Vector3(0.5f, 0.5f, 0f);
        FindObjectOfType<CustomerManager>().NotifyCustomerServed();

        StartCoroutine(LeaveAfterDelay());
    }

    private IEnumerator LeaveAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        Vector3 exitPos = new Vector3(transform.position.x, transform.position.y + 5f, 0);
        
        while (Vector3.Distance(transform.position, exitPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Destroy(gameObject); 
        FindObjectOfType<CustomerManager>().CustomerLeft();
    }
}
