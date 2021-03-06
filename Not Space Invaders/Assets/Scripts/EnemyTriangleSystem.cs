using System.Collections;
using UnityEngine;

public class EnemyTriangleSystem : Enemy
{
    public EnemyTriangleSystem()
    {
        this.health = GameOptions.difficulty;
        this.speed = 1f;
        this.scoreValue = 100*GameOptions.difficulty;
    }

    private bool canMove = true;
    private float fireRate = 1.1f-(0.2f*(float)GameOptions.difficulty);
    private float nextFire = 0.0f;
    private Renderer rend;

    public Transform firePosition;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveIfNotFiring();
        AttackPlayer();
        if (this.gameObject.transform.position.y < range)
            Destroy(this.gameObject);
    }


    void AttackPlayer()
    {
        if(PlayerController.isAlive == true)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            Vector2 direction = player.transform.position - transform.position;
            float dist = direction.magnitude;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
            transform.rotation = Quaternion.Euler(0f, 0f, angle-90);


            if (Time.time > nextFire && PauseMenu.isPaused == false)
            {
                canMove = false;
                nextFire = Time.time + fireRate;
                Instantiate(projectilePrefab, firePosition.position, transform.rotation);
                StartCoroutine(TimerToMove());
            }
        }
    }

    void MoveIfNotFiring()
    {
        if (!PlayerController.isAlive)
            return;

        if (canMove)
            transform.position += speed * Time.deltaTime * Vector3.down;
    }

    IEnumerator TimerToMove()
    {
        yield return new WaitForSeconds(0.5f); // Find the perfect number
        canMove = true;
    }
}
