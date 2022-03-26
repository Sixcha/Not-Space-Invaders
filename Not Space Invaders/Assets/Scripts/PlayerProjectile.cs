using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Vector2 firingPoint;
    public float range = 5f;

    [SerializeField]
    private float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position;
    }

    private void FixedUpdate()
    {
        DestroyOutOfReach();
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if (!PlayerController.isAlive)
            return;

        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime); 
    }

    void DestroyOutOfReach()
    {
        if (transform.position.y > range)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")) 
        {
            Destroy(this.gameObject);
        }

    }

}
