using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject Player;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
      Vector2 position = this.transform.position;
      position.x -= speed;
      this.transform.position = position;

      if(position.x <= -13 && position.y < 10)
      {
        Destroy(this.gameObject);
      }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("Player"))
      {
        for(int i = 0; i < 10000; i++);
        Destroy(this.gameObject);
      }
    }
}
