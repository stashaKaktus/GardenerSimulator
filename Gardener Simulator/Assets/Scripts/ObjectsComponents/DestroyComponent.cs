using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
