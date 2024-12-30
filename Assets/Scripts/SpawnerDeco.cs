using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerDeco : MonoBehaviour
{
    [SerializeField]
    private BoolValueSO gameStart;

    [SerializeField]
    private Spawner spawners;

    [SerializeField]
    private float timeBetweenSpawn = 3f;

    [SerializeField]
    private float[] spawnPos;

    public IntValueSO nbObj;
    // Start is called before the first frame update
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
    public IEnumerator Spawn()
    {

        yield return new WaitForSeconds(timeBetweenSpawn);

        float pos = spawnPos[Random.Range(0, spawnPos.Length)];

        Vector2 position = new Vector2(pos, transform.position.y);
        spawners.SpawnObject(position);

        StartCoroutine(Spawn());
        nbObj.Value++;
        Debug.Log(nbObj.Value);
    }

    public IEnumerator ReduceTimeBetweenSpawn()
    {
        yield return new WaitForSeconds(30);
        timeBetweenSpawn -= 0.25f;

        if (timeBetweenSpawn > 0.5f)
        {
            StartCoroutine(ReduceTimeBetweenSpawn());
        }
    }
}
