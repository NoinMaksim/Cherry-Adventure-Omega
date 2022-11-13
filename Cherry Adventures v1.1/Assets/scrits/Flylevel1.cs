using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flylevel1 : MonoBehaviour
{
    
    public Transform heroTransform;
    

    public float speedFly = 7f;    
    bool targetTime = true;
    bool permission = false;
    public int targetTimeInSec = 6;
    public GameObject flyClone;
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
        if (!targetTime && !permission)
        {
            FlyDelite();
        }
        if (targetTime && permission)
           flyClone.transform.position = Vector2.MoveTowards(flyClone.transform.position, heroTransform.position, speedFly * Time.deltaTime);
        
             
    }

    private void TimeTargetForHero()
    { 
           targetTime = false;
    }
   
    private void FlyDelite()
    {
        Debug.Log("delite");
        targetTime = false;
        Destroy(gameObject);      
    }

    public void InitializeteFly()
    {
       flyClone = Instantiate(flyClone, new Vector2(9,2.3f), Quaternion.Euler(0, 0, 0));
       Invoke("TimeTargetForHero",targetTimeInSec);
       permission = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        targetTime = false;
       Invoke( "FlyDelite",0.2f);
    }
}
 