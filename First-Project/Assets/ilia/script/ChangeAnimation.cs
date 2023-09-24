using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    public Animator animator;
    

    private void Start()
    {
        
        
         
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
            
        }else if(GoHome.Season_Counter >=27 && GoHome.Season_Counter <36)

        {
            animator.Play("bird");
        }
        else if(GoHome.Season_Counter >=36 && GoHome.Season_Counter <45)
        {
            animator.Play("warmingup");
        }
        else if(GoHome.Season_Counter >= 45 && GoHome.Season_Counter < 54)
        {
            animator.Play("smell");
        }
        else if(GoHome.Season_Counter >=54 && GoHome.Season_Counter <63 )
        {
            GoHome.Season_Counter = 9;

        }
        
        
        

    }
}
