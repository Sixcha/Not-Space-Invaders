using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        Debug.Log(xInput);
        float yInput = Input.GetAxisRaw("Vertical");
        Debug.Log(yInput);
        movement = new Vector2 (xInput, yInput);

        MovementWithTranslate(movement);
    }

    void FixedUpdate()
    {

    }

    // It overrides any physics that is used on the object which means object will not clash to other objects and get effected by it.
    void MovementWithTranslate(Vector2 direction)
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
