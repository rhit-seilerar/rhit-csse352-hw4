using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{
    static bool shouldReinitialize = true;
    static T instance;
    static GameObject parent;
    public static T Instance
    {
        get
        {
            if (instance == null && shouldReinitialize)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                    instance = parent?.AddComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null)
        {
            if (parent != gameObject)
                Destroy(gameObject);
            else
                Destroy(this);
        }

        instance = this as T;
        parent = gameObject;

        if (parent.transform.parent == null)
            DontDestroyOnLoad(parent);
    }

    protected static void Destroy()
    {
        shouldReinitialize = false;
        Destroy(instance);
    }
}
