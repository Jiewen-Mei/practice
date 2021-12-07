using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHit : MonoBehaviour
{
	public static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    
	public void TriggerAnimation()
   {
	   Debug.Log("triggering...");
	   anim.SetTrigger("isHit");
	   
 
   }
   
}
