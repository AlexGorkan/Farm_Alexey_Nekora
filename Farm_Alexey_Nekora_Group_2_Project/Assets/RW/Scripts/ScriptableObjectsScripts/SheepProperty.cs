using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/newSheepProperty")]
public class SheepProperty : ScriptableObject
{
    [SerializeField] private string sheepName;
    [SerializeField] private float speed;
    [SerializeField] private Material material;


    public string Name 
    {
        get 
        {
            if (sheepName == "")
            {
                Debug.LogWarning("No Sheep Name");
                return "None Name";
            }
            else
            {
                return sheepName;
            }
        }
        set
        {
            sheepName = value;
        }

    }
    public float Speed // svoistvo dlja peremennoi speed
    { 
        get 
        { 
            return speed; //poluchaem znachenie iz peremennoi speed
        }
        //private set
        //{
        //    speed = value; //value - prisvoenoe znachenie 
        //}
            
    }
    //private void Awake() // izmenjaem skorost tolko tut
    //{
    //    Speed = 10f;
    //}


    public Material Material => material; // poluchaem get
    //public Material Material { get { return material; } }
        
}
