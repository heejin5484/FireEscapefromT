using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Rank : MonoBehaviour
{
    public Text[] email = new Text[10];
    public Text[] score = new Text[10];
    // Start is called before the first frame update
    void Start()
    {
        DBRepository.Instance.selectRank();
        // DBRepository.Instance.selectMyRank();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
