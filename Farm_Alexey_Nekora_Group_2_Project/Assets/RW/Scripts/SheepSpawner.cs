using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] private GameObject sheepPrefab; //prefab ovci
    [SerializeField] private Vector3 spawnPosition; //tochka spawna 55 0 0
    [SerializeField] private Vector2 xSpawnBounds; //granici spawna po osi x (random point in range)

    [SerializeField] private int sheepCount; //schetchik ovec
    [SerializeField] private float spawnRate; //chastota spawna ovec
    [SerializeField] private float waveRate; //chastota mezhdu volnami
    [SerializeField] private int sheepCountWaveIncrease; //v skolko raz uvelichita volna

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    //private void CreateSheep() //sozdanie funkcii spawna
    //{ 

    //}
    private IEnumerator Spawn() // sozdaem coroutine
    {
        while (true) // beskonechni cikl
        {
            for (int i = 0; i < sheepCount; i++)
            {
                CreateSheep(); //spawn
                yield return new WaitForSeconds(spawnRate); // timer spawna ovec

            }
            sheepCount *= sheepCountWaveIncrease; //uvelichivaet kolichestvo voln
            yield return new WaitForSeconds(waveRate); // timer voln

        }
    }
    private void CreateSheep()
    {
        float xRandomPosition = Random.Range(xSpawnBounds.x, xSpawnBounds.y); // diapazon 1-6 daet randomnoe chislo
        Vector3 randomSpawnPosition = new Vector3(xRandomPosition, spawnPosition.y, spawnPosition.z); //sozdaetsa novaia coordinata 
        Instantiate(sheepPrefab, randomSpawnPosition, sheepPrefab.transform.rotation); //spawn ovec s uslovijami v skobkah
        
    }
}
