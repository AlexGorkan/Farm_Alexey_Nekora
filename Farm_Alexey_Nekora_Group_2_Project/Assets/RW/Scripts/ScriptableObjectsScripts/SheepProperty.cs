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
    [SerializeField] private List<Material> sheepMaterials;
    private int randomMaterial;

    public float Size
    {
        get
        {
            return sheepSize;
        }
        set
        {
            sheepSize = value;
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
                Debug.LogWarning("�������� �� ������. ����������� ����������� ��������.");
                return 10f;
                
            }
            else
            {
                return speed;
            }
        }
        
        set
        {
            if (speed >= 12f)
            {
                Debug.LogWarning("�� ��������� ��������. ����������� ����������� ��������.");
                speed = 10f;
                
            }
            else
            {
                speed = value; //value - prisvoenoe znachenie 
            }
            
        }
            
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
            int randomMaterials = Random.Range(0, sheepMaterials.Count);
            return sheepMaterials[randomMaterials];
             
        }
    }



}
