using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destroySelf");
    }

    //destroy the bullet once it's out of range. float time is the duration of delay
    IEnumerator destroySelf()
    {
        float time = 1f;
        yield return new WaitForSeconds(time);
        Destroy(this);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
