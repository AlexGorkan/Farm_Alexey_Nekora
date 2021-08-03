using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorMovement : MonoBehaviour
{
    enum TractorCondition { Move, Stop, Reload } //all conditions of tractor
    TractorCondition tractorCondition = TractorCondition.Stop; //default  condition of tractor

    [Header("Fire Property")]
    [SerializeField] private GameObject senoPrefab; //chem streliat (ssilka na object)
    [SerializeField] private SoundManager soundManager;
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

    [Header("SenoPool")]

    [SerializeField] private int senoPoolSize; //razmer poola
    private List<GameObject> senos; //objecti v poole
    private int currentSenoIndex;

    private void Awake()
    {
        senos = new List<GameObject>(); //sozdaem spisok dlja poola

    }


    private void Start()
    {
        for (int i = 0; i < senoPoolSize; i++)
        {
            senos.Add(Instantiate(senoPrefab)); //sozdaem object i pomesharm v list
            senos[i].transform.SetParent(senoContainer); // pomeschaem seno v senocontainer
            senos[i].SetActive(false); // deactivacia objecta

        }


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

            senos[currentSenoIndex].transform.position = spawnPoint.position; //berem seno iz poola pod indeksom 0 (currentSenoIndex = 0 po default)
            senos[currentSenoIndex].SetActive(true); // aktiviruem prefab
            currentSenoIndex++; // dobavljaem schetchik

            if (currentSenoIndex >= senoPoolSize) // proverka na zapolnenie poola dja sbrosa na 0 index
            {
                currentSenoIndex = 0;
            }
            //GameObject seno = Instantiate(senoPrefab, spawnPoint.position, Quaternion.identity);
            //Destroy(seno, 15f);

            senoAmount--; //otnimaem seno iz magazina
            soundManager.PlayShootClip();


        }
        
        
    }


    public void PressLeft()
    {
        soundManager.PlayClickButtonClip();
        direction = 1f;
        tractorCondition = TractorCondition.Move;
        
    }

    public void PressRight()
    {
        direction = -1;
        tractorCondition = TractorCondition.Move;
        soundManager.PlayClickButtonClip();
    }

    public void StopPress()
    {
        tractorCondition = TractorCondition.Stop;
        
    }
       

}
