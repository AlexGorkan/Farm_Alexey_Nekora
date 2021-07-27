using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SheepProperty", menuName = "ScriptableObjects/newSheepProperty")]
public class SheepProperty : ScriptableObject
{
    [SerializeField] private string sheepName;
    [SerializeField] private float speed;
    [SerializeField] private float sheepSize;
    [SerializeField] private Material material;
        
    public Vector3 Size
    {
        get
        {
            return new Vector3 (sheepSize, sheepSize, sheepSize);
        }
        
       
    }
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
            if (speed == 0f)
            {
                Debug.LogWarning("Скорость не задана. Установлена стандартная скорость.");
                return 10f;
                
            }
            else
            {
                return speed;
            }
        }
        
        //set
        //{
        //    if (speed >= 12f)
        //    {
        //        Debug.LogWarning("Вы превысили скорость. Установлена стандартная скорость.");
        //        speed = 10f;
                
        //    }
        //    else
        //    {
        //        speed = value; //value - prisvoenoe znachenie 
        //    }
            
        //}
            
    }
    //private void Awake() // izmenjaem skorost tolko tut
    //{
        
    //}


    //public Material Material => material; // poluchaem get
    //public Material Material { get { return material; } }
    public Material Material
    {
        get 
        {
            return material;
             
        }
    }



}
