using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSingleManager : MonoBehaviour
{
    // public static TitleSingleManager Instance = null;
    private static TitleSingleManager _instance;
    public static TitleSingleManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TitleSingleManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject("TitleSingleManager");
                    _instance = go.AddComponent<TitleSingleManager>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        // if (Instance == null)
        // {
        //     Instance = new TitleSingleManager();
        // }
        // else if (Instance != this)
        // {
        //     Destory(gameObject);
        // }
        // Instance = this;
        // DontDestoryOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public long FE_first_use;
    public long T_Fire_fighter;
    public long FE_use;
    public long FE_all_use;
    public long first_bucket;
    public long bucket_success;
    public long handkerchief_use;
    public long swift_evacuation;
    public long safe_evacuation;
    public long FITMOS;

    public void setTitle(long FE_first_use, long T_Fire_fighter, long FE_use, long FE_all_use, long first_bucket, long bucket_success, long handkerchief_use, long swift_evacuation, long safe_evacuation, long FITMOS)
    {
        this.FE_first_use = FE_first_use;
        this.T_Fire_fighter = T_Fire_fighter;
        this.FE_use = FE_use;
        this.FE_all_use = FE_all_use;
        this.first_bucket = first_bucket;
        this.bucket_success = bucket_success;
        this.handkerchief_use = handkerchief_use;
        this.swift_evacuation = swift_evacuation;
        this.safe_evacuation = safe_evacuation;
        this.FITMOS = FITMOS;
    }

    public bool setFE_first_use()
    {
        if (FE_first_use == 0)
        {
            FE_first_use = 1;
            return true;
        }
        return false;
    }
    public bool setT_Fire_fighter()
    {
        if (T_Fire_fighter == 0)
        {
            T_Fire_fighter = 1;
            return true;
        }
        return false;
    }

    public bool setFE_use()
    {
        if (FE_use == 0)
        {
            FE_use = 1;
            return true;
        }
        return false;
    }
    public bool setFE_all_use()
    {
        if (FE_all_use == 0)
        {
            FE_all_use = 1;
            return true;
        }
        return false;
    }

    public bool setfirst_bucket()
    {
        if (first_bucket == 0)
        {
            first_bucket = 1;
            return true;
        }
        return false;
    }

    public bool setbucket_success()
    {
        if (bucket_success == 0)
        {
            bucket_success = 1;
            return true;
        }
        return false;
    }

    public bool sethandkerchief_use()
    {
        if (handkerchief_use == 0)
        {
            handkerchief_use = 1;
            return true;
        }
        return false;
    }

    public bool setswift_evacuation()
    {
        if (swift_evacuation == 0)
        {
            swift_evacuation = 1;
            return true;
        }
        return false;
    }

    public bool setsafe_evacuation()
    {
        if (safe_evacuation == 0)
        {
            safe_evacuation = 1;
            return true;
        }
        return false;
    }
    public bool setFailBucket()
    {
        if ((FITMOS & (long)0001 << 3) == 0)
        {
            Debug.Log(1 << 2);
            FITMOS = FITMOS | 1000;
            if (FITMOS == 15)
            {
                return true;
            }
        }
        return false;
    }

    public bool setFailOxygen()
    {
        if ((FITMOS & (0001 << 2)) == 0)
        {
            FITMOS |= 0100;
            if (FITMOS == 15)
            {
                return true;
            }
        }
        return false;
    }

    public bool setFailFire()
    {
        if ((FITMOS & (0001 << 1)) == 0)
        {
            FITMOS = FITMOS | 0010;
            if (FITMOS == 15)
            {
                return true;
            }
        }
        return false;
    }

    public bool setFailElevator()
    {
        if ((FITMOS & (0001 << 0)) == 0)
        {
            FITMOS = FITMOS | 0001;
            if (FITMOS == 15)
            {
                return true;
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}