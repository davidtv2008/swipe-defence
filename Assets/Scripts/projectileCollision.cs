using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D fireball;
    public float speed;

    void Start()
    {
        fireball = GetComponent<Rigidbody2D>();

        float posx = transform.position.x;

        
        if(posx > 0f){
            speed = speed * -1f;
        }        
        
        fireball.AddForce(new Vector2(speed,0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

        float posy = transform.position.y;

        if(posy < -6f){
            Destroy(this.gameObject);
        }


    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(this.gameObject);
        //Debug.Log("projectile collision");
    }

    
}
