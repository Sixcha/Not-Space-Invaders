using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector2 firingPoint;
    public float range = -5f;
    public float xRange = 10f;


    private float projectileSpeed = 5.5f+(float)GameOptions.difficulty*0.2f;

    private float ballProjectileSpeed = 3f+(float)GameOptions.difficulty*0.1f;

    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position;
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if(transform.position.y < range || Mathf.Abs(transform.position.x) > xRange)
            Destroy(this.gameObject);
        else
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }

    }
}
