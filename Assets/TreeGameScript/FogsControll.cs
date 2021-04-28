using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FogsControll : MonoBehaviour
{
    [SerializeField] Vector3 mapScale;
    //整張地圖的大小
    [SerializeField] Vector3 fogScale = Vector3.up;
    //每一塊霧的大小
    [SerializeField] SpriteRenderer fogSprite;
    //霧的Prefab，Layer是Fogs

    List<SpriteRenderer> fogs = new List<SpriteRenderer>();
    //用於儲存所有霧塊
    [SerializeField] List<Sight> sights = new List<Sight>();
    void Start()
    {
        mapScale.y = Camera.main.orthographicSize;
        mapScale.x = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        GenerateFogs();
    }

    // Update is called once per frame
    void Update()
    {
        FindSights();
        UpdateFogs();
    }
    void GenerateFogs()
    {
        for (float x = (-Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height)); x < mapScale.x +.5f; x += fogScale.x)
        {
            for (float y = (-Camera.main.orthographicSize); y < mapScale.y; y += fogScale.y)
            {
                Vector3 fogPos = new Vector3(x, y);

                SpriteRenderer fog = Instantiate(fogSprite, fogPos, Quaternion.identity, transform);

                fog.transform.localScale = fogScale;

                fogs.Add(fog);
            }
        }
    }
    void FindSights()
    {
        sights = FindObjectsOfType<Sight>().ToList();
    }
    void UpdateFogs()
    {
        ResetFogs(); 
        //重設所有霧塊

        foreach (var sight in sights) 
            //所有具有視線的物件
        {
            List<SpriteRenderer> sightInFog = fogs.FindAll(n => Vector3.Distance
                    (n.transform.position, sight.transform.position) < sight.SightRange);
            //找出所有在視線中的霧塊

            FogLight(sightInFog);
            //隱藏所有在視線中的霧塊

        }
    }
    void ResetFogs()
    {
        foreach (var fog in fogs)
        {
            fog.gameObject.SetActive(true);
            //把所有霧塊啟用
        }
    }
    void FogLight(List<SpriteRenderer> fogs)
    {
        foreach (var fogSprite in fogs)
        {
            fogSprite.gameObject.SetActive(false);
            //關閉在視線中的霧塊        

            Color fogColor = fogSprite.color;

            fogSprite.color = fogColor;                                                        //設置霧塊不透明度
        }
    }
}
