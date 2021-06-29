using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateAxis;
    private Transform wheelTrans; //sozdaem otdelnij Transform dla childa
    void Start()
    {
        wheelTrans = transform.GetChild(0).GetChild(0); // odnoi oderaciej 
    }

    
    void Update()
    {
        //transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime); //rotates whole object
        //transform.GetChild(0).GetChild(0).transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime); // mnogo gruzit sistemu, plohoi sposob
        wheelTrans.transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime);
    }
}
