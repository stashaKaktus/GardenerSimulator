using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{ 
    private void Start()
    {
        StartCoroutine(SomeCoroutine());
    }

    /*    private IEnumerator SomeCoroutine()
        {
            while (enabled)
            {
                Debug.Log("work");
                yield return null;
                Debug.Log("work to");
            }
        }*/

    private IEnumerator SomeCoroutine()
    {
        while (enabled)
        {
            Debug.Log("work");
            yield return new WaitForSeconds(1f);
            Debug.Log("work to");
        }
    }
}
