using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    float speed = 100f;

    bool isGet;             // �l���ς݃t���O
    float lifeTime = 0.5f;  // �l����̐������� 
    public Text ItemText;   //�A�C�e���̃e�L�X�g
    private int item = 0;   //�A�C�e���X�R�A�v�Z
    public int  notesScore = 0; //�m�[�c�X�R�A���v


    void Start()
    {
        item = 0;
    
    }

    void Update()
    {

        SetItem();

        // �l����
        if (isGet)
        {
            // �f������]
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

        }
        // �l���O
        else
        {
            // ��������]
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
        ItemText.text = string.Format("�l�������F{0}", item);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[���ڐG�Ŋl������
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;

            // �R�C������Ƀ|�b�v������
            transform.position += Vector3.up * 1.5f;
        }
    }
}
