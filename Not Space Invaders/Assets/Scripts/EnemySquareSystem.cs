using UnityEngine;

public class EnemySquareSystem : Enemy
{
    [SerializeField]
    private static int hp = 2;

    

    [SerializeField]
    private float speed = 2f;

    private float range = -5f;

    [SerializeField]
    private int scoreValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
