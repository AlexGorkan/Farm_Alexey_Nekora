using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

// snachalapodkluchit prostransvo imen UnityEngine.Events
public class CollisionTractorWithSheep : MonoBehaviour
{
    [SerializeField] private UnityEvent SaveSheepEvent; // sozdaem event 

    private void OnTriggerEnter(Collider other)
    {
        Sheep sheep = other.gameObject.GetComponent<Sheep>();

        if (sheep != null)
        {
            sheep.DestroySheep();
            
            //SaveSheepEvent.Invoke();
        }
    }
}
