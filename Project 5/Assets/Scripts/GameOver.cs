using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text txt;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
      score = GameObject.Find("Score");
      txt.text =  "Distance: " + Mathf.RoundToInt((float)score.GetComponent<Score>().score).ToString() + "m";
      Destroy(score.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
