using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    public int Health { get; set; }

    private int ScoreValue { get; set; }

    [SerializeField]
    protected float speed;

    protected static float range = -5f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Health = Health;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchTowardsPlayer();
        if (transform.position.y < range)
            Destroy(this.gameObject);
    }

    public void TakeDamage(int damageAmount = 1)
    {
        Health -= damageAmount;
        if (Health < 0)
        {
            Destroy(this.gameObject);
            Score.UpdateScore(ScoreValue);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet")) 
        {
            TakeDamage();
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
