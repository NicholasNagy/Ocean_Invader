using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBlastController : MonoBehaviour
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
        //mainBlast = GetComponent<Rigidbody2D>();
        countCooldown = 0;
        //velocity = new Vector2(0.0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        //currentPosition = new Vector2(mainBlast.transform.position.x, mainBlast.transform.position.y);
        //mainBlast.MovePosition(currentPosition + velocity);

        if (Input.GetMouseButton(0) && countCooldown == 0)
        {
            countCooldown = 1;
            Invoke("BlastTheFucker", 0.5f);
        }
    }

    void BlastTheFucker()
    {
        if (player.gameObject.activeSelf)
        {
            Vector3 adjustment = new Vector3(0.1f, 0.1f, 0.0f);
            GameObject newBlast = Instantiate(theMainBlast, player.transform.position + adjustment, player.transform.rotation);

            newBlast.GetComponent<Rigidbody2D>().MovePosition(player.transform.position + adjustment);
            countCooldown = 0;
            Destroy(newBlast, 5);
        }
        
    }
}
