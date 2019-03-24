using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoshi : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public AudioSource jump;
    public AudioSource double_jump;
    public AudioSource death;
    void Start()
    {
      anim = GetComponent<Animator>();
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
        if (Input.GetKeyDown("space"))
        {
          if(anim.GetBool("Jump") == false)
          {
            jump.Play();
            anim.SetBool("Jump", true);
            anim.SetBool("DoubleJump", false);
          }
          else
          {
            double_jump.Play();
            anim.SetBool("DoubleJump", true);
          }
          position.y += 5;
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
