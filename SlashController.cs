using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashController : MonoBehaviour
{

    public float lifeTime;  
    void Start()
    {
        StartCoroutine(coroutineA());
    }


    void Update()
    {
        
    }
    IEnumerator coroutineA()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
