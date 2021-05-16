using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnProjectile : MonoBehaviour
{

    public GameObject projectile;
    public float targetTime = .1f;
    private float restartTime;
    // Start is called before the first frame update
    void Start()
    {
        restartTime = targetTime;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if(targetTime <= 0.0f){
            //create projectile after timer is up, reset timer
            targetTime = restartTime;
            Instantiate(projectile, new Vector3(Random.Range(-8.0f, 8.0f),5,0), Quaternion.identity);        
        }        
    }
}
