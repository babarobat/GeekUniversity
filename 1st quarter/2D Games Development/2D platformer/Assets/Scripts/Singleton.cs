using UnityEngine;
using System;
/// <summary>
/// Синглтон
/// </summary>
/// <typeparam name="T"></typeparam>
[DisallowMultipleComponent]
public class Singleton<T> : MonoBehaviour where T : Component
{

    //private static T _instance;
    //private static object _lock = new object();
    //private static bool _applicationIsQuitting;

    //public static T Instance
    //{
    //    get
    //    {

    //        lock (_lock)
    //        {
    //            if (_instance == null)
    //            {
    //                _instance = (T)FindObjectOfType(typeof(T));
    //                if (FindObjectsOfType(typeof(T)).Length > 1)
    //                {
    //                    Debug.Log(_instance);
    //                    return _instance;
    //                }
    //                if (_instance == null)
    //                {
    //                    GameObject singleton = new GameObject();
    //                    _instance = singleton.AddComponent<T>();
    //                    singleton.name = String.Format("{0} {1}",
    //                    "(singleton) ", typeof(T));
    //                    DontDestroyOnLoad(singleton);
    //                }
    //            }

    //            return _instance;
    //        }
    //    }
    //}
    //public void OnDestroy()
    //{
    //    _applicationIsQuitting = true;
    //}


    private static T instance;


    public static T Instance

    {

        get

       {

            if (instance == null)

            {

                instance = FindObjectOfType<T>();

                if (instance == null)

                {

                    GameObject obj = new GameObject();

                    obj.name = typeof(T).Name;

                    instance = obj.AddComponent<T>();

                }

            }

            return instance;

      }

    }


    protected virtual void Awake()

    {

        if (instance == null)

        {

            instance = this as T;

            DontDestroyOnLoad(gameObject);

        }

        else

        {

            Destroy(gameObject);

        }

    }

}

