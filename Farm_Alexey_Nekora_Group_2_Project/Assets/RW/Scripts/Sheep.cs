using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    //[SerializeField] private SheepProperty sheepProperty;
    [SerializeField] private List<SheepProperty> sheepProperty; //������ scriptable object for randomization

    //[SerializeField] private float startSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float force; //sila prizhka
    [SerializeField] private float riverJumpForce; //sila prizhka
    [SerializeField] private GameObject particleHearths; //������ �� ������� � ���� ����������
    [SerializeField] private Vector3 sheepOffset; //sdvig koordinat dlja spawna particle effecta

    private Rigidbody rb; //poluchaem rigidbody ovci
    private BoxCollider bcol; //poluchaem box collider ovci
    private float moveSpeed;
    private MeshRenderer mRenderer; // poluchaem komponent Mesh Renderer
    enum SheepConditions { Stop, Move, Jump } //sovdat sostoyanie enum
    SheepConditions sheepConditions = SheepConditions.Move; //prisvoit startovoe znachenie
    private int randomSheepPropertyIndex;

    [SerializeField] private SoundManager soundManager;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //poluchaem komponent ovci
        bcol = GetComponent<BoxCollider>(); //poluchaem komponent ovci 
        mRenderer = GetComponent<MeshRenderer>(); // poluchaem MeshRenderer
    }
    private void Start()
    {
        int randomSheepPropertyIndex = Random.Range(0, sheepProperty.Count);
        


        Debug.Log(sheepProperty[randomSheepPropertyIndex].Name);// get sheep name
        sheepProperty[randomSheepPropertyIndex].Name = "Molly"; // set sheep name
        Debug.Log(sheepProperty[randomSheepPropertyIndex].Name);// get sheep name
        transform.localScale = sheepProperty[randomSheepPropertyIndex].Size;


        mRenderer.material = sheepProperty[randomSheepPropertyIndex].Material; // prisvaivaem material iz ship proprty
        moveSpeed = sheepProperty[randomSheepPropertyIndex].Speed; // prisvaivaem speed iz ship proprty
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

        soundManager.PlaySheepHitClip(); // vizivaem zvuk 
        
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
        moveSpeed = sheepProperty[randomSheepPropertyIndex].Speed;
        sheepConditions = SheepConditions.Move;
    }
}
