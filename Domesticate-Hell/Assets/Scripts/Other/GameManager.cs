// Cattatonicat 2019
// For Domesticate Hell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// SINGLETON //

public class GameManager : MonoBehaviour
{
    // SerializeField // 

    private static int soulCount = 666;
    private static int human = 0;
    private static bool hasFireKey = false;
    private static bool hasShadowkey = false;
    private static bool hasElectricityKey = false;
    private static bool hasAlchemyKey = false;

    // getter & setter // 

    public static int SoulCount
    {
        get { return soulCount; }
        set { soulCount += value; }
    }

    public static int Human
    {
        get { return human; }
        set { human += value;  }
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
    

