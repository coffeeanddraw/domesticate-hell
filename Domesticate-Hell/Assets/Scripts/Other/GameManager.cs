// Cattatonicat 2019 
// For Domesticate Hell 
// https://www.instagram.com/cattatonicat/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SINGLETON //

public class GameManager : MonoBehaviour
{ 

    private static int soulCount = 0;
    private static int humanCount = 0;
    private static bool hasFireKey = false;
    private static bool hasShadowkey = false;
    private static bool hasElectricityKey = false;
    private static bool hasAlchemyKey = false;
    private static string timeString = "";

    // getter & setter // 

    public static int SoulCount
    {
        get { return soulCount; }
        set { soulCount = value; }
    }

    public static int HumanCount
    {
        get { return humanCount; }
        set { humanCount = value; }
    }

    public static bool HasFireKey
    {
        get { return hasFireKey; }
        set { hasFireKey = value; }
    }

    public static bool HasShadowKey
    {
        get { return hasShadowkey; }
        set { hasShadowkey = value; }
    }

    public static bool HasElectricityKey
    {
        get { return hasElectricityKey; }
        set { hasElectricityKey = value; }
    }

    public static bool HasAlchemyKey
    {
        get { return hasAlchemyKey; }
        set { hasAlchemyKey = value; }
    }

    public static string TimeString
    {
        get { return timeString; }
        set { timeString = value; }
    }

    public static GameManager Instance
    {
        // return reference to private instance 
        get
        {
            return Instance;
        }
    }

    private static GameManager instance = null;

    void Awake()
    {
        // Destroy secondary instances of GameManager
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        // Make this instance the only instance of GameManager
        instance = this;

        // Immortal Object
        DontDestroyOnLoad(gameObject);
    }

}
    

