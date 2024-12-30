using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> allObstacles;

    public void SpawnObject()
    {

        int random = Random.Range(0, allObstacles.Count);

        GameObject obstacle = allObstacles[random];

        GameObject.Instantiate(obstacle, transform.position, obstacle.transform.rotation);
    }

    public void SpawnObject(Vector2 pos)
    {

        int random = Random.Range(0, allObstacles.Count);

        GameObject obstacle = allObstacles[random];

        GameObject.Instantiate(obstacle, pos, obstacle.transform.rotation);
    }
}