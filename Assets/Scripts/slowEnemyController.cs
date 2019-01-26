using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowEnemyController : MonoBehaviour
{
    public GameObject Enemy;

    private Vector2 currentPosition;
    private Vector2 velocity;
    private float pathEnd;
    private float extremeHorizontalPosition;
    private float movementStartHeight;

    void Start()
    {
        velocity = new Vector2(0.0f, -0.025f);
        extremeHorizontalPosition = Enemy.transform.position.x;
        movementStartHeight = Random.Range(3.0f, 4.0f);
    }

    void Update()
    {
        currentPosition = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y);

        if(extremeHorizontalPosition < 0)
        {
            if (Enemy.transform.position.x >= -extremeHorizontalPosition)
            {
                velocity = new Vector2(0.0f, -0.025f);
            }

            else if (Enemy.transform.position.y <= movementStartHeight)
            {
                velocity = new Vector2(0.025f, -0.01f);
            }
        }
        else if (extremeHorizontalPosition > 0)
        {
            if (Enemy.transform.position.x <= -extremeHorizontalPosition)
            {
                velocity = new Vector2(0, -0.025f);
            }
            else if (Enemy.transform.position.y <= movementStartHeight)
            {
               velocity = new Vector2(-0.025f, -0.01f);
            }

        }
        

        
        Enemy.GetComponent<Rigidbody2D>().MovePosition(currentPosition + velocity);
        
    }
}
