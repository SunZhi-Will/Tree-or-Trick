using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimes : MonoBehaviour
{
    TreeAimControll g_Tac;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name.IndexOf("Attack")>-1){
            if(g_Tac == null){
                g_Tac = GameObject.FindGameObjectWithTag("TreeAim").GetComponent<TreeAimControll>();
            }else{
                transform.GetChild(0).gameObject.GetComponent<Text>().text = g_Tac.bullteNum + "";
            }
        }
        else{
            transform.GetChild(0).gameObject.GetComponent<Text>().text = WinConditions.g_TreeHp + "";
            
        }
    }
}
