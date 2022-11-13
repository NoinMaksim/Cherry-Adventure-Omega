using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flylevel1 : MonoBehaviour
{
    
    public Transform heroTransform;
    public GameObject fly;

    public float speedFly = 7f;    
    bool targetTime = true;
    bool permission = false;
    public int targetTimeInSec = 6;
    private void Awake()
    {
        heroTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    

    private void Update()
    {
        FlyTrans();
    }
    
    private void FlyTrans()
    {
        if (targetTime && permission)
            transform.position = Vector2.MoveTowards(transform.position, heroTransform.position, speedFly * Time.deltaTime);
        else
            FlyDelite();     
    }

    private void TimeTargetForHero()
    { 
           targetTime = false;
    }
   
    private void FlyDelite()
    {
        Destroy(fly);
    }

    public void InitializeteFly(Vector2 transformfly)
    {
        Instantiate(fly, transformfly, Quaternion.Euler(0, 0, 0));
        Invoke("TimeTargetForHero",targetTimeInSec);
        permission = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(fly);
    }
}
 