using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float force; //sila prizhka
    private Rigidbody rb; //poluchaem rigidbody ovci
    [SerializeField] private GameObject particleHearths;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //poluchaem komponent ovci
    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void SaveSheep()
    {
        rb.isKinematic = false; //obrashaemsa k rigidbody ovci i otkluchaem kinematiku chtobi vkluchit fiziku
        rb.AddForce(Vector3.up * force); //prilagaem silu
        //otkluchit box collider
        GameObject particles = Instantiate(particleHearths, transform.position, particleHearths.transform.rotation);
        Destroy(gameObject, 0.9f); //ovca destr s zaderzhkoy
        Destroy(particles, 2f); //destroy particles
    }
}
