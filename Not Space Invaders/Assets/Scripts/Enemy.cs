using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    public int health { get; set; }

    protected int scoreValue { get; set; }

    [SerializeField]
    protected float speed { get; set; }

    protected static float range = -5f;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TakeDamage(int damageAmount = 1)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Score.UpdateScore(scoreValue);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet")) 
        {
            TakeDamage();
        }

    }


}
