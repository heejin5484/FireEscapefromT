using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBSend : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("test");
        TitleSingleManager.Instance.setbucket_success();
        DBRepository.Instance.saveDB(123123);

    }
}
