using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    [SerializeField]
    private BoolValueSO gameStart;

    [SerializeField]
    private List<Spawner> spawners;

    [SerializeField]
    private float timeBetweenSpawn = 3f;

    [SerializeField]
    private IntValueSO gift;
    public IntValueSO nbObj;
    private void Start()
    {
        gameStart.onValueChange += OnGameStart;
    }

    private void OnDestroy()
    {
        gameStart.onValueChange -= OnGameStart;
    }

    public void OnGameStart(bool value)
    {
        if (value) 
        {
            StartCoroutine(Spawn());
            StartCoroutine(ReduceTimeBetweenSpawn());
        }
    }

    public int GetNbSpawn()
    {
        int gift = this.gift.Value;
        int nbSpawn = 1;
        if(gift < 5)
        {
            nbSpawn = 1;
        }
        else if(gift >= 5 && gift < 10) 
        {
            nbSpawn = 2;
        }
        else if (gift >= 10 && gift < 20)
        {
            nbSpawn = 3;
        }
        else if (gift >= 20 && gift < 30)
        {
            nbSpawn = 4;
        }
        else if (gift >= 30)
        {
            nbSpawn = 5;
        }

        return nbSpawn;
    }

    public IEnumerator Spawn()
    {
      
        yield return new WaitForSeconds(timeBetweenSpawn);
        
        int nbspawn = GetNbSpawn();
        int getNbToSpawn = Random.Range(1, nbspawn+1);
       
        int[] exludedSpawn = new int[getNbToSpawn];
        for (int i = 0; i < getNbToSpawn; i++)
        {
            int random;
            do
            {
                random = Random.Range(0, spawners.Count);
            }
            while(exludedSpawn.Contains(random));

            exludedSpawn[i] = random;

            spawners[random].SpawnObject();
            nbObj.Value++;
            Debug.Log(nbObj.Value);
        }
        StartCoroutine(Spawn());

    }

    public IEnumerator ReduceTimeBetweenSpawn()
    {
        yield return new WaitForSeconds(30);
        timeBetweenSpawn -= 0.25f;

        if(timeBetweenSpawn > 0.5f)
        {
            StartCoroutine(ReduceTimeBetweenSpawn());
        }
    }
}
