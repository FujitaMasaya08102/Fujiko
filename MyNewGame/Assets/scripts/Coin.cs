using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    float speed = 100f;

    bool isGet;             // 獲得済みフラグ
    float lifeTime = 0.5f;  // 獲得後の生存時間 
    public Text ItemText;   //アイテムのテキスト
    private int item = 0;   //アイテムスコア計算
    public int  notesScore = 0; //ノーツスコア合計


    void Start()
    {
        item = 0;
    
    }

    void Update()
    {

        SetItem();

        // 獲得後
        if (isGet)
        {
            // 素早く回転
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

        }
        // 獲得前
        else
        {
            // ゆっくり回転
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string itemTag = collision.gameObject.tag;

        if(itemTag=="Item10")
        {
            item += 10;
        }
        else if (itemTag == "Item20")
        {
            item += 20;
        }

       

    }
    void SetItem()
    {
        ItemText.text = string.Format("獲得音符：{0}", item);
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが接触で獲得判定
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;

            // コインを上にポップさせる
            transform.position += Vector3.up * 1.5f;
        }
    }
}
