using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTopTrigger : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            print("Player exited from ladder");
            boxCollider.isTrigger = false;
            Invoke("SetIsTriggerToTrue", 5f);
        }
    }
    
    private void SetIsTriggerToTrue()
    {
        boxCollider.isTrigger = true; 
    }
}
