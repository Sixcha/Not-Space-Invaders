using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquareSystem : MonoBehaviour
{
    [SerializeField]
    private static int hp = 2;

    public HealthSystem health = new HealthSystem(hp);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet")) 
        {
            health.Damage(PlayerProjectile.damage);
            Destroy(other.gameObject);
            if (health.GetHealth() <= 0)
            {
                Destroy(gameObject);
                // Leave score increase function here
            }
        }

    }
}
