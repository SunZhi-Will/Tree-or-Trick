using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChildAI : MonoBehaviour
{
    public string dire = "Left";
    string[] allDire;
    public float speed = 1.5f;
    int index;
    public Animator childAni;
    bool stop = false;
    void Start()
    {
        allDire = new string[4];
        for (int i = 0; i < allDire.Length; i++)
        {
            allDire[i] = "";
        }
        index = Random.Range(0, allDire.Length);

        if (transform.position.x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            dire = "Right";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) { 
        switch (dire)
        {
            case "Right":
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            case "Left":
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                break;
            case "Up":
                transform.Translate(-Vector2.down * speed * Time.deltaTime);
                break;
            case "Down":
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                break;
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            for (int i = 0; i < allDire.Length; i++)
            {
                allDire[i] = "";
            }
            if (collision.gameObject.GetComponent<CheckPoint>().AllDire)
            {
                allDire[0] = "Right";
                allDire[1] = "Left";
                allDire[2] = "Up";
                allDire[3] = "Down";
            }
            if (collision.gameObject.GetComponent<CheckPoint>().Up)
            {
                allDire[2] = "Up";
            }
            if (collision.gameObject.GetComponent<CheckPoint>().Down)
            {
                allDire[3] = "Down";
            }
            if (collision.gameObject.GetComponent<CheckPoint>().Left)
            {
                allDire[1] = "Left";
            }
            if (collision.gameObject.GetComponent<CheckPoint>().Right)
            {
                allDire[0] = "Right";
            }
            while (allDire[index] == "")
            {
                index = Random.Range(0, allDire.Length);
            }
            dire = allDire[index];
            if (dire == "Left")
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if (dire == "Right")
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        if(collision.gameObject.tag == "Tree" && !stop)
        {
            childAni.SetTrigger("Attack");
            stop = true;
        }
    }
}
