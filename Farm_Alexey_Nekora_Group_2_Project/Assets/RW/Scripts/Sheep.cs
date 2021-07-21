using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float force; //sila prizhka
    [SerializeField] private float riverJumpForce; //sila prizhka
    private Rigidbody rb; //poluchaem rigidbody ovci
    private BoxCollider bcol; //poluchaem box collider ovci
    [SerializeField] private GameObject particleHearths; //ссылка на партикл в этой переменной
    [SerializeField] private Vector3 sheepOffset; //sdvig
    enum SheepConditions { Stop, Move, Jump } //sovdat sostoyanie enum
    SheepConditions sheepConditions = SheepConditions.Move; //prisvoit startovoe znachenie
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //poluchaem komponent ovci
        bcol = GetComponent<BoxCollider>(); //poluchaem komponent ovci 
    }
    private void Start()
    {
        moveSpeed = startSpeed;
    }
    void Update()
    {
        if (sheepConditions == SheepConditions.Move)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        
    }
    public void SaveSheep()
    {
        rb.isKinematic = false; //obrashaemsa k rigidbody ovci i otkluchaem kinematiku chtobi vkluchit fiziku
        rb.AddForce(Vector3.up * force); //prilagaem silu
        rb.useGravity = false; //otkluchaem gravitaciyu
        bcol.enabled = false; // otkluchit boxcollider
        sheepConditions = SheepConditions.Stop;  
        GameObject particles = Instantiate(particleHearths, transform.position + sheepOffset, particleHearths.transform.rotation); //sozdaem instance particla
        Destroy(gameObject, 0.9f); //ovca destr s zaderzhkoy
        Destroy(particles, 2f); //destroy particles s zaderzhkoy
        
    }

    public void RiverJump()
    {

        rb.isKinematic = false; //obrashaemsa k rigidbody ovci i otkluchaem kinematiku chtobi vkluchit fiziku
        rb.AddForce(new Vector3(0f, 1f, -1f) * riverJumpForce); //prilagaem silu prizhku cherez reku
        sheepConditions = SheepConditions.Jump;
    }

    public void SheepLanding()
    {
        rb.isKinematic = true;
        moveSpeed = startSpeed;
        sheepConditions = SheepConditions.Move;
    }
}
