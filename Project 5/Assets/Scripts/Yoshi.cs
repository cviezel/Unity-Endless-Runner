using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yoshi : MonoBehaviour
{
  // Start is called before the first frame update
  public Animator anim;
  public Rigidbody2D rb;
  public AudioSource jump;
  public AudioSource double_jump;
  public AudioSource death;
  public AudioSource gameOver;
  public AudioSource bg;
  public BoxCollider2D col;
  public GameObject score;
  int jumps;
  bool gameFlag = true;
  void Start()
  {
    anim = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    col = GetComponent<BoxCollider2D>();
    jumps = 2;
    bg.Play();
  }

  // Update is called once per frame
  void Update()
  {
    score.GetComponent<Score>().score += 0.1;
    Vector2 position = this.transform.position;
    Quaternion rotation = this.transform.rotation;
    position.x = -2;
    rotation.z = 0;
    this.transform.position = position;
    this.transform.rotation = rotation;
    if(transform.position.y <= -10 && gameFlag == true) //fell off map
    {
      gameOver.Play();
      death.Play();
      bg.Stop();
      gameFlag = false;
      end();
    }
    if(rb.velocity.y > 0) //phases through platforms if going up
    {
      col.isTrigger = true;
    }
    else
    {
      col.isTrigger = false;
    }
    if (Input.GetKeyDown("space") && jumps > 0 && gameFlag == true)
    {
      col.isTrigger = true;
      if(anim.GetBool("Jump") == false) //single jump
      {
        jump.Play();
        anim.SetBool("Jump", true);
        anim.SetBool("DoubleJump", false);
        rb.velocity = new Vector2(0,0);
        rb.AddForce(Vector2.up * 400);
        jumps--;
      }
      else //double jump
      {
        double_jump.Play();
        anim.SetBool("DoubleJump", true);
        rb.velocity = new Vector2(0,0);
        rb.AddForce(Vector2.up * 350);
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

  void end(){
    //for(long i = 0; i < 10000000; i++);
    //System.Threading.Thread.Sleep(5000);
    SceneManager.LoadScene("Game Over");
  }
}
