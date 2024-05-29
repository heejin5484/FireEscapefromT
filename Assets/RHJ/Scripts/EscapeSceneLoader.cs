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
        // Ư�� ������Ʈ �ı�
        if (objectToDestroy != null)
        {
            Destroy(objectToDestroy);
        }

        // �� ��ȯ
        SceneManager.LoadScene(sceneToLoad);
    }
}
