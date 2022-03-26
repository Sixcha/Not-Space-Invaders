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
   
    }

    // Update is called once per frame
    void Update()
    {
        MoveDownwards();
        if (this.gameObject.transform.position.y < range)
            Destroy(this.gameObject); 
    }

    void MoveDownwards()
    {
        if (!PlayerController.isAlive)
            return;

        transform.position += speed * Time.deltaTime * Vector3.down;
    }
}
