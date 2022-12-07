using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float speed = 100f;

    bool isGet;             // Šl“¾Ï‚İƒtƒ‰ƒO
    float lifeTime = 0.5f;  // Šl“¾Œã‚Ì¶‘¶ŠÔ 

    void Start()
    {

    }

    void Update()
    {
        // Šl“¾Œã
        if (isGet)
        {
            // ‘f‘‚­‰ñ“]
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

        }
        // Šl“¾‘O
        else
        {
            // ‚ä‚Á‚­‚è‰ñ“]
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ƒvƒŒƒCƒ„[‚ªÚG‚ÅŠl“¾”»’è
        if (!isGet && other.CompareTag("Player"))
        {
            isGet = true;

            // ƒRƒCƒ“‚ğã‚Éƒ|ƒbƒv‚³‚¹‚é
            transform.position += Vector3.up * 1.5f;
        }
    }
}
