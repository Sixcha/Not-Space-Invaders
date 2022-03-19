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
    int protectors = GameOptions.difficulty*2;

    bool attackIsFinished = true;

    private float attackRate = 3f-(0.5f*(float)GameOptions.difficulty);
    private float nextAttack = 0.0f;

    private int previousAttack;
    private int attackToUse;
 
    void Start()
    {
        int aliveProtectors = protectors;
        nextAttack = Time.time + attackRate;
    }

    void Update()
    {
        InitiateAttack();
    }

    void InitiateAttack()
    {
        if(!attackIsFinished)
        {
            if(Time.time > nextAttack && PauseMenu.isPaused == false)
            {
                nextAttack = Time.time + attackRate;
                int attackCheck = Random.Range(1,3);

                if (attackCheck == previousAttack)
                {
                    attackToUse = Random.Range(1,3);
                }

                else
                {
                    attackToUse = attackCheck;
                }

                previousAttack = attackToUse;
                UseAttack(attackToUse);
            }
            
        }

    }

    void UseAttack(int attackNumber)
    {
        switch (attackNumber)
        {
            case 1:
            break;

            case 2:
            break;

            case 3:
            break;

            default:
            break;
        }
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
