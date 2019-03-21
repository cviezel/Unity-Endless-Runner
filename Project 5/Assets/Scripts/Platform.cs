using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      Vector2 position = this.transform.position;
      position.x -= speed;
      this.transform.position = position;
    }
}
