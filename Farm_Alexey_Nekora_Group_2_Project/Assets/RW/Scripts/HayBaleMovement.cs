using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayBaleMovement : MonoBehaviour
{
    [SerializeField] private float haySpeed;
    [SerializeField] private float hayBaleRotateSpeed;
    [SerializeField] private Vector3 hayBaleRotateAxis;
    private Transform hayBaleRotationTrans;
     

    void Start()
    {
        hayBaleRotationTrans = transform.GetChild(0); //getting child transform
    }

    
    void Update()
    {
        hayBaleRotationTrans.transform.Rotate(hayBaleRotateAxis * hayBaleRotateSpeed * Time.deltaTime); // child rotation
        transform.Translate(Vector3.forward * haySpeed * Time.deltaTime); // parent movement


    }
}
