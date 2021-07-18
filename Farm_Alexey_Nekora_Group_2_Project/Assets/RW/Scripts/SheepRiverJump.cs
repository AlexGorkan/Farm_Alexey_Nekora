using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRiverJump : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider triggerPoint)
    {
        Sheep sheepModel = triggerPoint.gameObject.GetComponent<Sheep>(); // poluchaem komponent u objekta s kotorim stolknulis s komponentom-sktiptom Sheep

        if (sheepModel != null)
        {
            sheepModel.RiverJump();
            
        }
    }
       
}
