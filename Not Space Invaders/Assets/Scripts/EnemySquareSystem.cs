using UnityEngine;

public class EnemySquareSystem : Enemy
{
    [SerializeField]
    

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
 

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
