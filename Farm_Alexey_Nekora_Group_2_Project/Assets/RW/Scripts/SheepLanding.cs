using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepLanding : MonoBehaviour
{
    private void OnTriggerEnter(Collider landingPoint)
    {
        Sheep sheepModel = landingPoint.gameObject.GetComponent<Sheep>(); // poluchaem komponent u objekta s kotorim stolknulis s komponentom-sktiptom Sheep

        if (sheepModel != null)
        {
            sheepModel.SheepLanding();

        }
    }
}
