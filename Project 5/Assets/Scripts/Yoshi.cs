using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
      anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
          anim.SetBool("Jump", true);
          Vector2 position;
          position = this.transform.position;
          position.y += 3;
          this.transform.position = position;
        }
    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("Platform") && anim.GetBool("Jump") == true)
      {
        anim.SetBool("Jump", false);
        anim.SetTrigger("Land");
      }
    }
}
