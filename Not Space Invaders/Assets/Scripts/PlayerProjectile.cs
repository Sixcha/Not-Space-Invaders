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

    // Start is called before the first frame update
    void Start()
    {
        firingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        /* if(Vector2.Distance(firingPoint, transform.position) > maxProjectileDistance)
            Destroy(this.gameObject);
        else
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime); */
        if(transform.position.y > range)
            Destroy(this.gameObject);
        else
            transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);
    }
}
