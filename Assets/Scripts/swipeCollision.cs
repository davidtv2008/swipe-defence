using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeCollision : MonoBehaviour
{
    public GameObject collisionParticles;
    private GameObject currentCollisionParticles;

    public float life = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){

        ContactPoint2D point = col.GetContact(0);
        Vector3 contactPoint = point.point;

        //Debug.Log(contactPoint);

        //add collision particle effect
        addCollisionEffect(contactPoint);

    }

    void addCollisionEffect(Vector3 pos){

        currentCollisionParticles = Instantiate(collisionParticles,pos,Quaternion.identity);

        currentCollisionParticles.transform.parent = this.transform;

        life -= 10f;

    }
}
