using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class Score
{
    public long score;
    public string email;
    public Score(string email, long score)
    {
        this.email = email;
        this.score = score;
    }
}

public class DBRepository : MonoBehaviour
{
    // public static DBRepository Instance = null;
    GameObject rankObject;
    private Queue<IDictionary> qq = new Queue<IDictionary>();
    private Queue<IDictionary> myRank = new Queue<IDictionary>();
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference reference;

    private static DBRepository _instance;
    public static DBRepository Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DBRepository>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("DBRepository");
                    _instance = go.AddComponent<DBRepository>();
                }
            }
            return _instance;
        }
    }
    string loginUserID;
    string loginUserEmail;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = new DBRepository();
        // }
        // else if (Instance != this)
        // {
        //     Destory(Instance);
        // }
        // Instance = this;
        // UnityEngine.Object.DontDestoryOnLoad(gameObject);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (qq.Count > 0)
        {
            IDictionary rank = qq.Dequeue();
            Debug.Log(rank["FITMOS"]);
            TitleSingleManager.Instance.setTitle((long)rank["FE_first_use"], (long)rank["T_Fire_fighter"], (long)rank["FE_use"], (long)rank["FE_all_use"], (long)rank["first_bucket"], (long)rank["bucket_success"], (long)rank["handkerchief_use"], (long)rank["swift_evacuation"], (long)rank["safe_evacuation"], (long)rank["FITMOS"]);
            string json = JsonUtility.ToJson(TitleSingleManager.Instance);
            Debug.Log(json);
        }
        if (myRank.Count > 0)
        {
            IDictionary rank = myRank.Dequeue();
            string email = (string)rank["email"];
            long score = (long)rank["score"];
            Debug.Log(email);
            Debug.Log(score);
            rankObject.GetComponent<Rank>().email[9].text = "<color=orange>" + email + "</color>";
            rankObject.GetComponent<Rank>().score[9].text = "<color=orange>" + score + "</color>";
        }
    }
    public void checkTitle()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Title").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                Debug.Log(snapshot);
                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary rank = (IDictionary)data.Value;
                    Debug.Log("이름: " + rank["userEmail"] + ", 점수: " + rank["fireExtinguisher"]);
                    // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                }
            }
        });
    }

    public void loginTitleDB(string userId, string userEmail)
    {
        this.loginUserID = userId;
        this.loginUserEmail = userEmail;
        FirebaseDatabase.DefaultInstance.GetReference("Title").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(userId);
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                foreach (DataSnapshot data in snapshot.Children)
                {
                    if (userId == data.Key)
                    {
                        IDictionary rank = (IDictionary)data.Value;
                        Debug.Log(rank["FITMOS"]);
                        qq.Enqueue(rank);
                    }

                }
            }
        });
    }

    public void saveDB(long score)
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        string json = JsonUtility.ToJson(TitleSingleManager.Instance);
        Debug.Log(json);
        Score score1 = new Score(loginUserEmail, score);
        Debug.Log(score1.email);
        string json2 = JsonUtility.ToJson(score1);
        Debug.Log(json2);
        reference.Child("Title").Child(loginUserID).SetRawJsonValueAsync(json);
        reference.Child("Score").Child(loginUserID).SetRawJsonValueAsync(json2);
    }

    public void logoutTitleDB()
    {
        loginUserID = null;
        loginUserEmail = null;
        TitleSingleManager.Instance.setTitle(0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
    }


    //계정 만들때 DB생성
    public void signupDBTile(string userId)
    {
        string json = JsonUtility.ToJson(TitleSingleManager.Instance);
        Debug.Log(json);
        reference.Child("Title").Child(userId).SetRawJsonValueAsync(json);
        // Score score = new Score()
        // string json = JsonUtility.ToJson(TitleSingleManager.Instance);
    }

    public void selectRank()
    {
        rankObject = GameObject.Find("RankObject");
        DatabaseReference tempreference = FirebaseDatabase.DefaultInstance.GetReference("Score");
        Query titleQuery = tempreference.OrderByChild("score").LimitToLast(9);
        titleQuery.ValueChanged += HandleValueChanged2;
    }

    private async void HandleValueChanged2(object sender, ValueChangedEventArgs args)
    {
        string[] emailArr = new string[10];
        long[] scoreArr = new long[10];
        int id = 8;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        if (args.Snapshot != null)
        {
            Firebase.Auth.FirebaseUser user2;
            foreach (var recode in args.Snapshot.Children)
            {
                // Debug.Log(recode.Key);
                // UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserAsync(recode.Key);
                // Debug.Log(userRecord);
                // user2 = auth.GetUserAsync(recode.Key).Result;
                // if (user2 != null)
                // {
                //     Debug.Log(user2);
                //     string email = user2.Email;
                //     Debug.Log(email);
                // }
                // Debug.Log(recode.Value);
                IDictionary rank = (IDictionary)recode.Value;
                // Debug.Log(rank["email"]);
                emailArr[id] = (string)rank["email"];
                scoreArr[id--] = (long)rank["score"];
                // Debug.Log(scoreArr[id--]);

                // Debug.Log(recode.GetRawJsonValue());
            }
        }
        // rankObject.GetComponent<Rank>().email[9].text = emailArr[9];
        for (int i = 0; i < emailArr.Length; i++)
        {
            // Debug.Log(emailArr[i]);
            // Debug.Log(scoreArr[i]);
            if (loginUserEmail == emailArr[i])
            {
                // Debug.Log(loginUserEmail);
                rankObject.GetComponent<Rank>().email[i].text = "<color=orange>" + emailArr[i] + "</color>";
                rankObject.GetComponent<Rank>().score[i].text = "<color=orange>" + scoreArr[i] + "</color>";
            }
            else
            {
                rankObject.GetComponent<Rank>().email[i].text = emailArr[i];
                rankObject.GetComponent<Rank>().score[i].text = scoreArr[i] + "";
            }

        }
    }

    public void selectMyRank()
    {
        rankObject = GameObject.Find("RankObject");

        FirebaseDatabase.DefaultInstance.GetReference("Score").GetValueAsync().ContinueWith(task =>
       {
           if (task.IsCompleted)
           { // 성공적으로 데이터를 가져왔으면
               DataSnapshot snapshot = task.Result;
               // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
               //    Debug.Log(snapshot);
               foreach (DataSnapshot data in snapshot.Children)
               {

                   //    Debug.Log(data);
                   if (data.Key == loginUserID)
                   {
                       IDictionary rank = (IDictionary)data.Value;
                       //    Debug.Log(loginUserID);
                       myRank.Enqueue(rank);

                   }
                   // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
               }
           }
       });
    }

    public void selectDate()
    {
        DatabaseReference tempreference = FirebaseDatabase.DefaultInstance.GetReference("Title");
        Query titleQuery = tempreference.OrderByChild("FITMOS");
        titleQuery.ValueChanged += HandleValueChanged;
    }

    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        if (args.Snapshot != null)
        {

            foreach (var recode in args.Snapshot.Children)
            {
                Debug.Log(recode.GetRawJsonValue());
            }
        }
        // Do something with the data in args.Snapshot
    }

    public void testOrder()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Title").OrderByValue().GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            { // 성공적으로 데이터를 가져왔으면
                DataSnapshot snapshot = task.Result;
                // 데이터를 출력하고자 할때는 Snapshot 객체 사용함
                Debug.Log(snapshot.GetRawJsonValue());

                // foreach (DataSnapshot data in snapshot.Children)
                // {
                //     IDictionary rank = (IDictionary)data.Value;
                //     Debug.Log("이름: " + rank["FITMOS"]);
                //     // JSON은 사전 형태이기 때문에 딕셔너리 형으로 변환
                // }
            }
        });
    }
}
