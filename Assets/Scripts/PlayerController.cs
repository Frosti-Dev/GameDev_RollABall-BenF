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
    public GameObject flashLight;
    public AudioSource pickupSound;
    public AudioSource gameEndSound;
    
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
     
            SetCountTextL3();
            winTextObject.SetActive(false);
            retryTextObject.SetActive(false);
            quitTextObject.SetActive(false);
            nextTextObject.SetActive(false);
        
    }

    void OnMove(InputValue movementValue)
    {
        
      Vector2 movementVector = movementValue.Get<Vector2>();

      movementX = movementVector.x;
      movementY = movementVector.y;
        
        
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        
       rb.AddForce(movement * speed);
       
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("PickUp"))
      {
            other.gameObject.SetActive(false);
            count = count + 1;
            pickupSound.Play();

            SetCountTextL3();
      }
        
        
    }
    

    void SetCountTextL3()
    {
        countText.text = "Count: " + count.ToString() + "/45";
        if (count >= 45)
        {
            gameEndSound.Play();
            winTextObject.SetActive(true);
            nextTextObject.SetActive(true);
            quitTextObject.SetActive(true);

            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            gameObject.SetActive(false);
            flashLight.SetActive(false);
            Cursor.visible = true;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameEndSound.Play();
            //Destroy(gameObject);
            gameObject.SetActive(false);
            flashLight.SetActive(false);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
            retryTextObject.SetActive(true);
            quitTextObject.SetActive(true);
            Cursor.visible = true;
        }

        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            gameEndSound.Play();
            gameObject.SetActive(false);
            flashLight.SetActive(false);

            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You lose!";
            retryTextObject.SetActive(true);
            quitTextObject.SetActive(true);
            Cursor.visible = true;
        }
    }
}
