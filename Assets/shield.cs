using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    public float hp = 100f;
    // Start is called before the first frame update
    public float lifeSpan = 3.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //destroy the game after its life is up
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0f){
            Destroy(gameObject);
        }

    }


    void OnCollisionEnter2D(Collision2D col){

        //deduct shield life after every hit
        switch(col.gameObject.name){
            case "projectile(Clone)" : 
                
                //every hit shield takes damage, update text
                hp -= 10f;
                if(hp <= 0f){
                    Destroy(gameObject);
                }

                Transform lifeText = gameObject.transform.Find("LifeText");
                TextMesh textMesh = lifeText.GetComponent<TextMesh>();
                textMesh.text = hp + "%";

            break;
            default:;
            break;
        }

        

        /*
        ContactPoint2D point = col.GetContact(0);
        Vector3 contactPoint = point.point;

        //Debug.Log(contactPoint);

        //add collision particle effect
        addCollisionEffect(contactPoint);

        */

    }

    void addCollisionEffect(Vector3 pos){

        /*
        currentCollisionParticles = Instantiate(collisionParticles,pos,Quaternion.identity);

        currentCollisionParticles.transform.parent = this.transform;

        life -= 10f;
        */

    }
}
