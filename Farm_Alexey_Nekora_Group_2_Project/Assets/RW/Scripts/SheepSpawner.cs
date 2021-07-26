using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private SheepProperty sheepProperty;
    [SerializeField] private List<Transform> spawnPoints; //spisok tochek spawna
    



    [SerializeField] private GameObject sheepPrefab; //prefab ovci
    [SerializeField] private Vector3 spawnPosition; //tochka spawna 55 0 0
    [SerializeField] private Vector2 xSpawnBounds; //granici spawna po osi x (random point in range)

    [SerializeField] private int sheepCount; //schetchik ovec
    [SerializeField] private float spawnRate; //chastota spawna ovec
    [SerializeField] private float waveRate; //chastota mezhdu volnami
    [SerializeField] private int sheepCountWaveIncrease; //v skolko raz uvelichitsa volna
    [SerializeField] private int maxWaves; //max colichestvo voln
    private int wavesCounter; //zapisivaet schetchik otspawnenix voln
    
    private void Start()
    {
        StartCoroutine(Spawn());
                
    }
       
    private IEnumerator Spawn() // sozdaem coroutine
    {
        while (wavesCounter <= maxWaves) // beskonechni cikl while(true) teper konechnii
        {
            for (int i = 0; i < sheepCount; i++)
            {
                CreateSheep(); //spawn ovec
                CreateSheepInSpawnPoints(); // spawn ovec v treh tochkax
                yield return new WaitForSeconds(spawnRate); // timer spawna ovec
                
            }
            sheepCount *= sheepCountWaveIncrease; //uvelichivaet kolichestvo voln
            yield return new WaitForSeconds(waveRate); // timer voln
            wavesCounter ++; //schetchik kolichestva zaspawnenix voln


        }
    }
    private void CreateSheep() //sozdanie funkcii spawna
    {
        //float xRandomPosition = Random.Range(xSpawnBounds.x, xSpawnBounds.y); // diapazon 1-6 daet randomnoe chislo
        //Vector3 randomSpawnPosition = new Vector3(xRandomPosition, spawnPosition.y, spawnPosition.z); //sozdaetsa novaia coordinata 
        //Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation); //spawn ovec s uslovijami v skobkah

        //korotkaya forma
        Instantiate(
            sheepPrefab, 
            new Vector3(Random.Range(xSpawnBounds.x, xSpawnBounds.y), 
                        spawnPosition.y, spawnPosition.z), 
            sheepPrefab.transform.rotation);
        
    }

    public void CreateSheepInSpawnPoints()
    {
        int randomPointIndex = Random.Range(0, spawnPoints.Count);
        Instantiate(sheepPrefab, spawnPoints[randomPointIndex].position, sheepPrefab.transform.rotation);
        
        
    }
}
