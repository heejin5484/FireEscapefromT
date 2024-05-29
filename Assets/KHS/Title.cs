using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public Text[] achievement = new Text[10];
    public Text action;
    DatabaseReference reference;
    Firebase.Auth.FirebaseUser user1;
    // Start is called before the first frame update
    void Start()
    {
        // Firebase.Auth.FirebaseAuth auth;
        // auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        // user1 = auth.CurrentUser;
        // // reference = FirebaseDatabase.DefaultInstance.RootReference;
        // reference = FirebaseDatabase.DefaultInstance.GetReference("Title");
        // User user = new User("hyjkl0124@naver.com", "kim");
        // string json = JsonUtility.ToJson(user);
        // string providerId;
        // string uid;
        //         if (user1 != null) {
        //             foreach (var profile in user1.ProviderData) {
        //               // Id of the provider (ex: google.com)
        //              providerId = profile.ProviderId;

        //     // UID specific to the provider
        //              uid = profile.UserId;
        //              Debug.Log(uid);
        //                  string name = profile.DisplayName;
        //     string email = profile.Email;
        //          reference.Child("Title").Child(email).SetRawJsonValueAsync(json);
        //     // Name, email address, and profile photo Url

        //         Debug.Log(providerId);
        //             Debug.Log(name);
        //                 Debug.Log(email);
        //     System.Uri photoUrl = profile.PhotoUrl;
        //   }
        // }
        // reference.GetValueAsync().ContinueWith(task =>
        // {
        //     if (task.IsCompleted)
        //     { // 성공적으로 데이터를 가져왔으면
        //         DataSnapshot snapshot = task.Result;
        //         // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
        //         Debug.Log(snapshot);
        //         foreach (DataSnapshot data in snapshot.Children)
        //         {
        //             IDictionary rank = (IDictionary)data.Value;
        //             Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["userName"]);
        //             // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
        //         }
        //     }
        // });
        if (TitleSingleManager.Instance.FE_first_use != 1)
        {
            achievement[0].text = "미달성";
        }
        if (TitleSingleManager.Instance.T_Fire_fighter != 1)
        {
            achievement[1].text = "미달성";
        }
        if (TitleSingleManager.Instance.FE_use != 1)
        {
            achievement[2].text = "미달성";
        }
        if (TitleSingleManager.Instance.FE_all_use != 1)
        {
            achievement[3].text = "미달성";
        }
        if (TitleSingleManager.Instance.first_bucket != 1)
        {
            achievement[4].text = "미달성";
        }
        if (TitleSingleManager.Instance.bucket_success != 1)
        {
            achievement[5].text = "미달성";
        }
        if (TitleSingleManager.Instance.handkerchief_use != 1)
        {
            achievement[6].text = "미달성";
        }
        if (TitleSingleManager.Instance.swift_evacuation != 1)
        {
            achievement[7].text = "미달성";
        }
        if (TitleSingleManager.Instance.safe_evacuation != 1)
        {
            achievement[8].text = "미달성";
        }
        if (TitleSingleManager.Instance.FITMOS != 15)
        {
            achievement[9].text = "미달성";
        }

    }

    public void checkData()
    {
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot);
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary rank = (IDictionary)data.Value;
                    Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["userName"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void onFire()
    {
        action.text = "1. 소화기를 가져와서 몸통을 단단히 잡고 안전핀을 뽑는다.\n \n2.노즐을 잡고 불쪽을 향해 가까이 이동한다.\n\n3.손잡이를 꽉 움켜쥔다.\n\n4.분말이 골고루 불을 덮을 수 있도록 쏜다.";
    }

    public void onBucket()
    {
        action.text = "A급 화재가 발생했을 때 물로 불을 끄는 방법은 효과적이지만 B급 이상의 화재는 오히려 불을 더 번지게 만들 수 있다.";
    }

    public void onHand()
    {
        action.text = "불길이 커져서 대피해야 할 경우 젖은 수건 또는 담요를 활용하여 계단을 통해 밖으로 대피합니다.";
    }
    public void onEscape()
    {
        action.text = "**1. 주변 사람에게 알립니다.\n2. 대피방법을 결정합니다.\n3. 신속히 대피합니다.\n4. 119로 신고합니다.\n5. 대피 후 인원을 확인합니다.";
    }
    public void onFail()
    {
        action.text = "1. 화재 원인을 모르는 상황에서는 화재 구역에 물을 뿌리면 안돼요.\n2. 연기가 많이 발생할 경우 손수건을 사용하세요.\n3. 화재가 발생할 경우 화재를 대비하여 문잡이를 잡거나 열지 마세요.\n4. 화재가 발생 시 승강기를 이용하지 마세요.";
    }
    public void goGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}