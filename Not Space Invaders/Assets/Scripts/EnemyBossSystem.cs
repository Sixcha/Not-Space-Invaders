using UnityEngine;

public class EnemyBossSystem : Enemy
{
    public EnemyBossSystem()
    {
        this.health = GameOptions.difficulty*10+40;
        this.speed = 1f;
        this.scoreValue = GameOptions.difficulty*1000;
    }

    bool isInvulnerable = true;
    int protectors = GameOptions.difficulty+1;
 
    void Start()
    {
        
    }

    void Update()
    {

    }

    void LaunchTowardsPlayer()
    {
        if(PlayerController.isAlive == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Transform playerPosition = player.transform;

            if (Vector2.Distance(transform.position, playerPosition.position) > 0.5f)
            {
                // Chase on x-axis
                if (transform.position.y > playerPosition.position.y)
                {
                    Vector2 xTarget = new Vector2(playerPosition.position.x, transform.position.y);
                    transform.position = Vector2.MoveTowards(transform.position, xTarget, speed * Time.deltaTime);
                }

                // Move down on y-axis
                transform.position += speed * Time.deltaTime * Vector3.down;
            }
        }
    }
}
