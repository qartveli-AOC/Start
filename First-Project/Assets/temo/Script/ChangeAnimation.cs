using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public Animator animator;
    

    private void Start()
    {
        
        animator = GetComponent<Animator>();
         
    }
    private void Update()
    {
        ChangeParticle(); 
        Debug.Log(GoHome.Season_Counter);
    }
    
    public void ChangeParticle()
    {
        if(GoHome.Season_Counter >=9&& GoHome.Season_Counter < 18)
        {
            Debug.Log(GoHome.Season_Counter);
            animator.Play("rain");
            
            
            
        }else if (GoHome.Season_Counter >= 18 && GoHome.Season_Counter < 27 )
        {

            Debug.Log(GoHome.Season_Counter);
            animator.Play("trembling");
            
        }else if(GoHome.Season_Counter >=27)

        {
            GoHome.Season_Counter = 0;
        }
        
        

    }
}
