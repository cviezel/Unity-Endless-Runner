using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    // Start is called before the first frame update
    public float spawnRate;
    float nextSpawn = 0;
    void Start()
    {
      Vector2 spawnLocInit = new Vector2(0f, -3.55f);
      Instantiate(platform, spawnLocInit, Quaternion.identity);

      Vector2 spawnLoc = new Vector2(15f, Random.Range(-4f, 4f));
      Instantiate(platform, spawnLoc, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
      if(Time.time > nextSpawn)
      {
        nextSpawn = Time.time + spawnRate;
        Vector2 spawnLoc = new Vector2(Random.Range(12f, 60f), Random.Range(-4f, 4f));
        Instantiate(platform, spawnLoc, Quaternion.identity);
      }
    }
}
