using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private bool isGameStarted;
    public float countDownTimer = 0.0f;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.0f;
    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        // Mark true when game is started
        isGameStarted = true;
        Debug.Log("Game is started!");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted)
        {
            //Debug.Log("Game is still running!");
        }

        // Allowing the user to end the game when escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGameStarted = false;
            Debug.Log("Game is ended because you pressed Escape!");
            Application.Quit();
        }

        // Counting the total running time of game
        countDownTimer += (1 * Time.deltaTime);

        // If user hold space make cube grow larger
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale += Vector3.one;
            //Debug.Log("You holding space");
        }

        // if user releases space key, cube scale is back to (1, 1, 1)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.localScale = Vector3.one;
            //Debug.Log("You released space");
        }

        // Rotating cube if user uses arrow keys
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, speed * horizontalInput * Time.deltaTime);

        transform.Rotate(Vector3.left, speed * verticalInput * Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        isGameStarted = false;
        Debug.Log("Game is ended on application quit!");
        Debug.Log("Total Game running time was " + countDownTimer);
        Debug.Log(Time.time);
    }
}
