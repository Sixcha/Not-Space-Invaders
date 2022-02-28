using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquareSystem : MonoBehaviour
{
    [SerializeField]
    private static int hp = 2;

    public HealthSystem health = new HealthSystem(hp);

    [SerializeField]
    private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LaunchTowardsPlayer();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet")) 
        {
            health.Damage(1);
            Destroy(other.gameObject);
            if (health.GetHealth() <= 0)
            {
                Destroy(gameObject);
                // Leave score increase function here
            }
        }

    }

    void LaunchTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.transform.position - transform.position;
        transform.Translate(direction * speed * Time.deltaTime);

    }
}
