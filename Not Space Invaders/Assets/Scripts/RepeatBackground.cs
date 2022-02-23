using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startPos;
    private float repeatHeight;

    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Starts background and the saves position to a Vector2
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider2D>().size.y / 3;
    }

    // Update is called once per frame
    void Update()
    {
        // Change the location of the object to (0, 1 * time * speed)
        transform.Translate(Vector2.down * Time.deltaTime * speed);

        // If passes 1/3 of its size, reposition to StartPoint
        if (transform.position.y < startPos.y - repeatHeight)
            transform.position = startPos;
    }
}
