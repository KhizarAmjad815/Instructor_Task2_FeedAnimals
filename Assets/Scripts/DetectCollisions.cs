using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.score++;
        GameManager.gameManager.UpdateScore();
        Destroy(gameObject);
        Destroy(other.gameObject);
        Debug.Log("Score is " + GameManager.score);
    }

    // Coroutine examples

    IEnumerator fade()
    {

        yield return new WaitForSeconds(0.5f);
    }
}
