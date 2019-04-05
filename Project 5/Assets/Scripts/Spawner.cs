using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject ghostPlatform;
    public GameObject droppingPlatform;
    public GameObject risingPlatform;
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
        Vector2 spawnLoc = new Vector2(Random.Range(12f, 50f), Random.Range(-4f, 4f));
        int x = Random.Range(0, 4);
        if(x == 0)
          Instantiate(platform, spawnLoc, Quaternion.identity);
        if(x == 1)
          Instantiate(ghostPlatform, spawnLoc, Quaternion.identity);
        if(x == 2)
          Instantiate(droppingPlatform, spawnLoc, Quaternion.identity);
        if(x == 3)
          Instantiate(risingPlatform, spawnLoc, Quaternion.identity);
      }
    }
}
