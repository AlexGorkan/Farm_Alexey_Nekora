using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSheepsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheepPrefab; //prefab ovci
    [SerializeField] private Vector3 spawnPosition; //pozicia spawna
    [SerializeField] private Transform[] spawnPoints;
    

    [SerializeField] private int sheepCount; //schetchik ovec
    [SerializeField] private float spawnRate; //chastota spawna ovec
    [SerializeField] private float waveRate; //chastota mezhdu volnami
    [SerializeField] private int sheepCountWaveIncrease; //v skolko raz uvelichitsa volna
    [SerializeField] private int maxWaves; //max colichestvo voln
    private int wavesCounter; //zapisivaet scetchik otspawnenix voln
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() // sozdaem coroutine
    {
        while (wavesCounter <= maxWaves) // beskonechni cikl while(true) teper konechnii
        {
            for (int i = 0; i < sheepCount; i++)
            {
                CreateSheep(); //spawn
                yield return new WaitForSeconds(spawnRate); // timer spawna ovec

            }
            sheepCount *= sheepCountWaveIncrease; //uvelichivaet kolichestvo voln
            yield return new WaitForSeconds(waveRate); // timer voln
            wavesCounter += 1; //schetchik kolichestva zaspawnenix voln

        }
    }
    private void CreateSheep() //sozdanie funkcii spawna
    {
        float RandomPosition = Random.Range(0, spawnPoints.Length); // randomnoe 
        Vector3 randomSpawnPosition = new Vector3(RandomPosition, spawnPosition.y, spawnPosition.z); //sozdaetsa novaia coordinata 
        Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation); //spawn ovec s uslovijami v skobkah
                
    }
}
