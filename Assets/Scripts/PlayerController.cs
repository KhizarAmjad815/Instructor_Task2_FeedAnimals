using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float xBound = 10;
    public GameObject projectilePrefab;

    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(firstCoroutine());
    }

    // Creating 2 Coroutines

    IEnumerator firstCoroutine()
    {
        Debug.Log("First couroutine created");

        yield return new WaitForSeconds(1.0f);

        yield return StartCoroutine(secondCoroutine());
        StopCoroutine(secondCoroutine());
        Debug.Log("Frist coroutine runnning again");
    }

    IEnumerator secondCoroutine()
    {
        Debug.Log("Second couroutine created");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("Now first coroutine will run again");
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
