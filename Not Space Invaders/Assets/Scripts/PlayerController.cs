using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 6.3f;
    public float yRange = 4.7f;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // To keep player in the boundaries demanded by values at the top
        if(transform.position.x < -xRange)
            transform.position = new Vector2(-xRange, transform.position.y);
        if(transform.position.x > xRange)
            transform.position = new Vector2(xRange, transform.position.y);
        if(transform.position.y < -yRange)
            transform.position = new Vector2(transform.position.x, -yRange);
        if(transform.position.y > yRange)
            transform.position = new Vector2(transform.position.x, yRange);

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Debug.Log($"x:{xInput}, y:{yInput}");

        movement = new Vector2(xInput, yInput).normalized;
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
