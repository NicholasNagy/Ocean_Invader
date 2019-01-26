using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseEnemyController : MonoBehaviour
{

    public GameObject Enemy;

    private Vector2 currentPosition;
    private Vector2 velocity;

    void Start()
    {
        velocity = new Vector2(0.0f, -0.1f);

    }

    void Update()
    {
        currentPosition = new Vector2(Enemy.transform.position.x, Enemy.transform.position.y);
        Enemy.GetComponent<Rigidbody2D>().MovePosition(currentPosition + velocity);
    }
}
