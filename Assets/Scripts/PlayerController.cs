using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpPower = 5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject retryTextObject;
    public GameObject quitTextObject;
    public GameObject nextTextObject;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool isGrounded;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if( sceneName == "Level1")
        {
            SetCountText();
            winTextObject.SetActive(false);
            retryTextObject.SetActive(false);
            quitTextObject.SetActive(false);
            nextTextObject.SetActive(false);
        }
        else if (sceneName == "Level2")
        {
            SetCountText();
            winTextObject.SetActive(false);
            retryTextObject.SetActive(false);
            quitTextObject.SetActive(false);
            nextTextObject.SetActive(false);
        }

        else
        {
            SetCountText();
            winTextObject.SetActive(false);
            retryTextObject.SetActive(false);
            quitTextObject.SetActive(false);
            nextTextObject.SetActive(false);
        }
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
       Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
       rb.AddForce(movement * speed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "Level1")
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;

                SetCountText();
            }
        }
        else if(sceneName == "Level2")
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;

                SetCountText2D();
            }
        }
        
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/12";
        if(count >= 12)
        {
            winTextObject.SetActive(true);
            nextTextObject.SetActive(true);
            quitTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }

    void SetCountText2D()
    {
        countText.text = "GET THE THE EXIT: " + count.ToString() + "/1";
        if (count == 1)
        {
            winTextObject.SetActive(true);
            nextTextObject.SetActive(true);
            quitTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
            retryTextObject.SetActive(true);
            quitTextObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            Destroy(gameObject);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
            retryTextObject.SetActive(true);
            quitTextObject.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

}
