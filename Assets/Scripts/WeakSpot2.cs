using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot2 : MonoBehaviour
{
    public GameObject objectToDestroy;
    public AudioClip killSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioManager.instance.PlayClipAt(killSound, transform.position);
            Destroy(objectToDestroy);
        }
    }
}
