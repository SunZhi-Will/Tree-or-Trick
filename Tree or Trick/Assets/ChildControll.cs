using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildControll : MonoBehaviour
{
    public float speed = 1.5f;
    public Animator childAni;
    string dire;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (transform.position.y < (Camera.main.orthographicSize - (transform.localScale.y / 2)))
            {
                transform.Translate(transform.up * Time.deltaTime * speed);
                childAni.SetBool("Run", true);
                
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (transform.position.y > ((-Camera.main.orthographicSize) + (transform.localScale.y / 2)))
            {
                transform.Translate(-transform.up * Time.deltaTime * speed);
                childAni.SetBool("Run", true);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < ((Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) - (transform.localScale.x / 2)))
            {
                transform.Translate(transform.right * Time.deltaTime * speed);
                childAni.SetBool("Run", true);
                if (dire != "Right")
                {
                    dire = "Right";
                    transform.rotation = new Quaternion(0,180,0,0);
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > ((-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)) + (transform.localScale.x / 2)))
            {
                transform.Translate(-transform.right * Time.deltaTime * speed);
                childAni.SetBool("Run", true);
                if (dire != "Left")
                {
                    dire = "Left";
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }
        if (!(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)))
        {
            childAni.SetBool("Run", false);
        }

    }
    public void Hunt()
    {
        childAni.SetTrigger("Hunt");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            collision.gameObject.GetComponent<TreeControll>().HitTree();
            
        }
    }
}
