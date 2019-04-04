using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject Player;
    bool dropFlag = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Vector2 position = this.transform.position;
      position.x -= speed;
      if(dropFlag)
      {
        position.y -= 0.03f;
      }
      this.transform.position = position;

      if(position.x <= -13 && position.y < 10)
      {
        Destroy(this.gameObject);
      }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("Player"))
        dropFlag = true;
    }
}
