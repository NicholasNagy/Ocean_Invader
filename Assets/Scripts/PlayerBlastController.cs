using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlastController : MonoBehaviour
{

    private int countCooldown;
    public GameObject player;
    public GameObject theMainBlast;

    private Vector2 velocity;
    private Vector2 currentPosition;

    private Rigidbody2D mainBlast;
    // Start is called before the first frame update
    void Start()
    {
        mainBlast = GetComponent<Rigidbody2D>();
        countCooldown = 0;
        velocity = new Vector2(0.0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = new Vector2(mainBlast.transform.position.x, mainBlast.transform.position.y);
        mainBlast.MovePosition(currentPosition+velocity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }


}
