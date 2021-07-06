using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorMovement : MonoBehaviour
{
    [Header("Fire Property")]
    [SerializeField] private GameObject senoPrefab; //chem streliat (ssilka na object)
    [SerializeField] private Transform spawnPoint; //tochka spawna na objekte
    [SerializeField] private float fireRate; //chastota spawna
    private float nextFire; 

    [Header("Tractor Property")]
    [SerializeField] private float speed;
    [SerializeField] private float bounds;
    private float direction;
    private bool isPress;
    //[SerializeField] private string fireMessage = "";


    private void Start()
    {
        nextFire = fireRate; // dlja plusovogo timera
    }
    void Update()
    {
        if (isPress)
        {


            if (((transform.position.x > -bounds) && (direction == 1f)) || ((transform.position.x < bounds) && (direction == -1f)))
            {
                transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
            }
        }

        nextFire += Time.deltaTime; // -= Time.deltaTime; minusovij timer



        //if (((transform.position.x > -bounds) && (direction == 1f)) || ((transform.position.x < bounds) && (direction == -1f)))
        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}


        //if ((transform.position.x > -bounds) && (direction ==1f))
        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}
        //else if ((transform.position.x < bounds) && (direction == -1f))

        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}





    }

    public void PressFire()
    {
        if (nextFire > fireRate) // (nextFire < 0)
        {
            GameObject seno = Instantiate(senoPrefab, spawnPoint.position, Quaternion.identity); // senoPrefab.transform.rotation - sohrahjaet povorot objecta prefaba
            Destroy(seno, 15f);

            nextFire = 0f; // nextFire = fireRate;
        }
        
        
        
    }


    public void PressLeft()
    {
        direction = 1f;
        isPress = true;
    }

    public void PressRight()
    {
        direction = -1;
        isPress = true;
    }

    public void StopPress()
    {
        //direction = 0f;
        isPress = false;
    }




}
