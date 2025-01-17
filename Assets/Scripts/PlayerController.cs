using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
    }
    // This function is called when a move input is detected.
    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
    }
    
}
