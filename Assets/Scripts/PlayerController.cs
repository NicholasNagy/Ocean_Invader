using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public int Health;
    //private Vector3 mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //transform.position = new Vector3(Input.touches[0].position.x,0,0);
            //Vector2 first = new Vector2(Input.mousePosition.x/45, rb2d.position.y);
            //Vector2 second = new Vector2(-Screen.width / 90, 0);
            //rb2d.MovePosition(Input.touches[0].position);


            rb2d.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Health--;
            if (Health == 0)
            {
                gameObject.SetActive(false);
                
                SceneManager.LoadScene("GameOver");
            }
            
        }
        
    }

}
