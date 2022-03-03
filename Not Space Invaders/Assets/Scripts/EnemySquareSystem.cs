using UnityEngine;

public class EnemySquareSystem : Enemy
{
    public EnemySquareSystem()
    {
        this.health = 2;
        this.speed = 0f;
        this.scoreValue = 200;
    }
 

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LaunchTowardsPlayer();
        if (this.gameObject.transform.position.y < range)
            Destroy(this.gameObject); 
    }

    void LaunchTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = player.transform.position;

        transform.Translate(direction * speed * Time.deltaTime);

    }
}
