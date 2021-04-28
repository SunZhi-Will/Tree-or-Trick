using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    public GameObject g_Tree;
    public GameObject g_Child;

    public GameObject[] g_TreeWin;
    public GameObject[] g_ChildWin;

    public int g_WinHitTreeNum = 4;
    public static int g_TreeHp = 4;
    // Start is called before the first frame update
    void Start()
    {
        g_TreeHp = g_WinHitTreeNum;
    }

    bool b=true;
    // Update is called once per frame
    void Update()
    {
        
        if(g_TreeHp < 1 && b){
            b=false;
            TreeOrChildWin(false);
        }
    }

    public void TreeOrChildWin(bool _TreeBool){
        g_Tree.SetActive(true);
        g_Child.SetActive(true);
        if(_TreeBool){
            foreach (var item in g_TreeWin)
            {
                item.SetActive(true);
                
            }
            EffectsMusic.AudioWinTree();
        }else{
            foreach (var item in g_ChildWin)
            {
                item.SetActive(true);
                
            }
            EffectsMusic.AudioWinChild();
        }
    }
}
