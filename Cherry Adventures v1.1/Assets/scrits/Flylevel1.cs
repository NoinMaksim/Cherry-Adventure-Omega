using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flylevel1 : MonoBehaviour
{
    
    public Transform heroTransform;
    public GameObject fly;

    public float speedFly = 7f;    
    bool targetTime = true;
    public int targetTimeInSec = 6;
    private void Awake()
    {
        heroTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        Invoke("TimeTargetForHero", targetTimeInSec);
    }

    private void Update()
    {
        FlyTrans();
    }
    
    private void FlyTrans()
    {
        if (targetTime)
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
}
 