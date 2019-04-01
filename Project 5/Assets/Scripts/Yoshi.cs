using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
  // Start is called before the first frame update
  public Animator anim;
  public Rigidbody2D rb;
  public AudioSource jump;
  public AudioSource double_jump;
  public AudioSource death;
  public BoxCollider2D col;
  int jumps;
  void Start()
  {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<BoxCollider2D>();
    jumps = 2;
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 position = this.transform.position;
    Quaternion rotation = this.transform.rotation;
    position.x = -2;
    rotation.z = 0;
    this.transform.position = position;
    this.transform.rotation = rotation;

    if(rb.velocity.y > 0) //phases through platforms if going up
    {
      col.isTrigger = true;
    }
    else
    {
      col.isTrigger = false;
    }
    if (Input.GetKeyDown("space") && jumps > 0)
    {
      if(anim.GetBool("Jump") == false) //single jump
      {
        jump.Play();
        anim.SetBool("Jump", true);
        anim.SetBool("DoubleJump", false);
        rb.velocity = new Vector2(0,0);
        rb.AddForce(Vector2.up * 350);
        jumps--;
      }
      else //double jump
      {
        double_jump.Play();
        anim.SetBool("DoubleJump", true);
        rb.velocity = new Vector2(0,0);
        rb.AddForce(Vector2.up * 300);
        jumps--;
      }

      //position.y += 5;
      //this.transform.position = position;
    }
  }
  void OnCollisionEnter2D (Collision2D col)
  {
    if(col.gameObject.tag.Equals("Platform") && anim.GetBool("Jump") == true)
    {
      anim.SetBool("Jump", false);
      anim.SetTrigger("Land");
      jumps = 2;
    }
  }
}
