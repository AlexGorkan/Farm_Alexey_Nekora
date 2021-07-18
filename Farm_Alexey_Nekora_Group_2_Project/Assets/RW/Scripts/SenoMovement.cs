using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateDirection;
    private Transform senoModel;

    void Start()
    {
        senoModel = transform.GetChild(0);
    }

   
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        senoModel.transform.Rotate(rotateSpeed * rotateDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Sheep sheep = other.GetComponent<Sheep>();
        if (sheep != null)
        {
            sheep.SaveSheep(); //vizov metoda SaveShepp iz skrita Sheep
            Destroy(gameObject); //seno destr
            
        }

        if (other.gameObject.tag == "SenoDestroyTrigger") // alternativa: other.CompareTag("SenoDestroyTrigger");
        {
            Destroy(gameObject); //destroy seno pri stolknovenii s "other" kotoroe trigger;
            //print(other.gameObject.name);
               
        }
       
        // vtoroi sposob sravnit 
        //if (other.gameObject.name == "SenoDestroyTrigger") // cherez component name
        //{
        //    Destroy(gameObject); 
            
        //}



    }

}
