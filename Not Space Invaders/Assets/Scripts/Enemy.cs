using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int hp;

    [SerializeField]
    protected float speed;

    protected static float range = -5f;

    [SerializeField]
    protected int scoreValue;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            if (transform.position.y < range)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet")) 
        {
            health.Damage(1);
            Destroy(other.gameObject);
            if (health.GetHealth() <= 0)
            {
                Destroy(this.gameObject);
                // Leave score increase function here
                Score.UpdateScore(scoreValue);
            }
        }

    }

    void LaunchTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.transform.position;

        if (transform.position.y < range)
            Destroy(this.gameObject);
        else
            transform.Translate(direction * speed * Time.deltaTime);
    }
}
