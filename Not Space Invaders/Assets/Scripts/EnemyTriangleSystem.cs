using UnityEngine;

public class EnemyTriangleSystem : Enemy
{
    public EnemyTriangleSystem()
    {
        this.health = 3;
        this.speed = 1f;
        this.scoreValue = 300;
    }
    
    private float fireRate = 0.8f;
    private float nextFire = 0.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        AttackPlayer();
        if (this.gameObject.transform.position.y < range)
            Destroy(this.gameObject); 
    }

    void AttackPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //Vector2 direction = player.transform.position;

        Vector2 direction = player.transform.position - transform.position;
        float dist = direction.magnitude;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
     
        transform.rotation = Quaternion.Euler(0f, 0f, angle-92);


        if(Time.time > nextFire && PauseMenu.isPaused == false)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectilePrefab, (transform.position + new Vector3(0, -0.5f, 0)), transform.rotation);
        }

    }
}
