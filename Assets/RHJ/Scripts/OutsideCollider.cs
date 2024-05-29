using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideCollider : MonoBehaviour
{
    [SerializeField] List<GameObject> TargetEvent;
    [SerializeField] GameObject NextEvent;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < TargetEvent.Count; i++)
            {
                TargetEvent[i].SetActive(true);
            }
        }
    }
}