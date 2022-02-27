using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Vector2 firingPoint;
    public float range = 5f;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float maxProjectileDistance;

    public int damage = 1;

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
        if(transform.position.y > range)
            Destroy(this.gameObject);
        else
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }
}
