using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Sheep sheep = other.gameObject.GetComponent<Sheep>(); // poluchaem komponent u objekta s kotorim stolknulis s komponentom-sktiptom Sheep

        if(sheep != null)
        {

            Destroy(other.gameObject); // destroy ovcu
        
        }
    }
}
