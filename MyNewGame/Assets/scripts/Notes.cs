using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    [SerializeField]
    private int notesPlus;

    [SerializeField]
    private GameObject uiObj;
    private UIContoroller uiContoroller;

    private void Start()
    {
        uiContoroller = uiObj.GetComponent<UIContoroller>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        string yourTag = collision.gameObject.tag;

        if (yourTag=="Player")
        {

            Destroy(gameObject);
        }
    }

}
