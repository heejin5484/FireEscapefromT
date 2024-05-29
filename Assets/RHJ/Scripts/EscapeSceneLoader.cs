using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private GameObject objectToDestroy;

    void Awake()
    {
        if (StateManager.Instance != null)
        {
            objectToDestroy = StateManager.Instance.gameObject;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DestroyObjectAndChangeScene();
        }
    }

    void DestroyObjectAndChangeScene()
    {
        // 특정 오브젝트 파괴
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }

        // 씬 전환
        SceneManager.LoadScene(sceneToLoad);
    }
}
