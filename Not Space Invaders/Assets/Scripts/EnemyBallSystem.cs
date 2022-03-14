using UnityEngine;

public class EnemyBallSystem : Enemy
{
    [SerializeField]
    float distanceLeftRight = 1f;

    public GameObject projectilePrefab;



    public EnemyBallSystem()
    {
        this.health = GameOptions.difficulty;
        this.speed = (float)GameOptions.difficulty + 1f;
        this.scoreValue = GameOptions.difficulty * 100;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LaunchTowardsPlayerSin();
        if (this.gameObject.transform.position.y < range)
            Destroy(this.gameObject);
    }

    void LaunchTowardsPlayerSin()
    {
        if (PlayerController.isAlive == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Transform playerPosition = player.transform;

            if (Vector2.Distance(transform.position, playerPosition.position) > 0.5f)
            {
                // Chase on x-axis
                if (transform.position.y > playerPosition.position.y)
                {
                    //Vector2 xTarget = new Vector2(playerPosition.position.x/2, transform.position.y);
                    //transform.position = Vector2.MoveTowards(transform.position, xTarget, speed * Time.deltaTime);
                    transform.position = new Vector2(Mathf.Sin(speed*0.8f * Time.time) * distanceLeftRight, transform.position.y);
                }

                // Move down on y-axis
                transform.position += speed * Time.deltaTime * Vector3.down;
            }
        }
    }

    private void OnDisable()
    {
        if (PlayerController.isAlive == true)
        {
            float difficulty = GameOptions.difficulty;
            for (int i = 0; i < 4 * (Mathf.Pow(difficulty, 2) - 2 * difficulty + 3); i++)
            Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, i * (60 - 15 * difficulty)));
        }
    }
}
