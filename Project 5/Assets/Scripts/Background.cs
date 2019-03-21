using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public float scrollSpeed;

    // Start is called before the first frame update
    /*
    private void Awake()
    {
      material = GetComponent<Renderer>().material;
    }
    */
    void Start()
    {
      material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
      offset = new Vector2(scrollSpeed, 0);
      material.mainTextureOffset += offset * Time.deltaTime;
    }
}
