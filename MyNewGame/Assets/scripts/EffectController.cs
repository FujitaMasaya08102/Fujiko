using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField]
    private float DeleteTime;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CollectEffect", DeleteTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CollectEffect()
    {
        Destroy(gameObject);
    }
}
