using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    public int health { get; set; }

    protected int scoreValue { get; set; }

    protected float speed { get; set; }

    protected static float range = -5f;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    public void TakeDamage(int damageAmount = 1)
    {
        SoundSystem.SetDamageSignal();
        health -= damageAmount;
        if (health <= 0)
        {
            SoundSystem.SetDestroySignal();
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
