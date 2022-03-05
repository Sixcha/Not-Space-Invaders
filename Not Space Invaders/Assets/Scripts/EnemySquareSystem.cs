using UnityEngine;

public class EnemySquareSystem : Enemy
{
    public EnemySquareSystem()
    {
        this.health = GameOptions.difficulty+1;
        this.speed = (float)GameOptions.difficulty+1f;
        this.scoreValue = GameOptions.difficulty*100;
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
