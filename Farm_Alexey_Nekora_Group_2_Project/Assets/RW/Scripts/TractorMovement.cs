using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorMovement : MonoBehaviour
{
    enum TractorCondition { Move, Stop, Reload } //all conditions of tractor
    TractorCondition tractorCondition = TractorCondition.Stop; //default  condition of tractor

    [Header("Fire Property")]
    [SerializeField] private GameObject senoPrefab; //chem streliat (ssilka na object)
    [SerializeField] private Transform spawnPoint; //tochka spawna na drugom objekte
    [SerializeField] private float fireRate; //chastota spawna
    [SerializeField] private int senoStartAmount; // startovoe kolichestvo sena v obojme
    private int senoAmount; // kolichestvo sena v obojme
    private float reloadComplete; // timer reloada
    private float nextFire;
    [SerializeField] Transform senoContainer;

    [Header("Tractor Property")]
    [SerializeField] private float speed;
    [SerializeField] private float bounds;
    private float direction;
    
    


    private void Start()
    {
        senoAmount += senoStartAmount;
        reloadComplete += senoStartAmount;
        //nextFire = fireRate; 
        // dlja plusovogo timera
    }
    void Update()
    {
        if (tractorCondition == TractorCondition.Move)
        {


            if (((transform.position.x > -bounds) && (direction == 1f)) || ((transform.position.x < bounds) && (direction == -1f)))
            {
                transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
            }
        }
               
        if (senoAmount <= 0)
        {
            
            tractorCondition = TractorCondition.Reload;
            tractorCondition = TractorCondition.Stop;
            reloadComplete -= Time.time;
            Debug.Log("Перезарядка завершится через: " + reloadComplete + " секунд");
        }
        
        //nextFire += Time.deltaTime; //dlja plusovogo timera
        // -= Time.deltaTime; minusovij timer schitaet



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
        //if (nextFire > fireRate) 
        //    // (nextFire < 0) dlja minusovogo
        //{
        //    GameObject seno = Instantiate(senoPrefab, spawnPoint.position, Quaternion.identity); // senoPrefab.transform.rotation - sohrahjaet povorot objecta prefaba
        //    Destroy(seno, 15f);

        //    nextFire = Time.time + fireRate;
        //    //nextFire = 0f; //dlja plusovogo
        //    // nextFire = fireRate; // dlja minusovogo
        //}
               
        if (Time.time > nextFire && senoAmount > 0)
        
        {
            nextFire = Time.time + fireRate;
            GameObject seno = Instantiate(senoPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(seno, 15f);
            seno.transform.SetParent(senoContainer);
            senoAmount--; //otnimaem seno iz magazina

        }
        
        
    }


    public void PressLeft()
    {
        direction = 1f;
        tractorCondition = TractorCondition.Move;
    }

    public void PressRight()
    {
        direction = -1;
        tractorCondition = TractorCondition.Move;
    }

    public void StopPress()
    {
        tractorCondition = TractorCondition.Stop;
    }




}
