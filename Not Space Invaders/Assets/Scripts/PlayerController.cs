using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float xRange = 6.3f;
    public float yRange = 4.7f;

    private Vector2 movement;

    public int bulletLevel = 0;
    public GameObject[] projectilePrefab = new GameObject[3];
    private const float fireRate = 0.15f;
    private float nextFire = 0.0f;

    public static bool isAlive = true;

    // Shoot Audio
    [SerializeField]
    private AudioSource _shootAudioSource;

    // Death Audio
    [SerializeField]
    private AudioSource _destroyedAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] Audios = GetComponents<AudioSource>(); // Audio does not work needs fix later
        _shootAudioSource = Audios[0];
        _destroyedAudioSource = Audios[1];
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerShoot(bulletLevel);
    }

    void PlayerMovement()
    {
        // To keep player in the boundaries demanded by values at the top
        if(transform.position.x < -xRange)
            transform.position = new Vector2(-xRange, transform.position.y);
        if(transform.position.x > xRange)
            transform.position = new Vector2(xRange, transform.position.y);
        if(transform.position.y < -yRange)
            transform.position = new Vector2(transform.position.x, -yRange);
        if(transform.position.y > yRange)
            transform.position = new Vector2(transform.position.x, yRange);

        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(xInput, yInput).normalized;
        transform.Translate(movement * Time.deltaTime * speed);
    }

    void PlayerShoot(int bulletLevel)
    {
        if(Input.GetKey("space") && Time.time > nextFire && PauseMenu.isPaused == false)
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectilePrefab[bulletLevel], (transform.position + new Vector3(0, 0.5f, 0)), transform.rotation);
            _shootAudioSource.Play();
        }
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) 
        {
            Destroy(this.gameObject);
            isAlive = false;
        }

    }

    void OnDestroy()
    {
        _destroyedAudioSource.Play();
    }
}
