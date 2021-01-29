using UnityEngine;
using System;

public abstract class SingleSceneSingleton<T> : MonoBehaviour where T : SingleSceneSingleton<T>
{
    protected static readonly object m_padlock = new object();

    protected static T instance = null;
    public static T Instance
    {
        get
        {

            lock (m_padlock)
            {
                if (instance == null)
                {
                    T sceneObject = FindObjectOfType<T>();
                    if (sceneObject)
                    {
                        instance = sceneObject;
                        return instance;
                    }
                    else
                    {
                        Debug.LogWarning($"Creating {typeof(T).ToString()} singleton because an instance does not yet exist in the scene. Add an instance yourself in the editor to avoid any undefined behaviour.");

                        instance = new GameObject(typeof(T).ToString() + " singleton").AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        protected set
        {
            instance = value;
        }
    }

    protected virtual void Awake()
    {
        Instance = (T)this;
    }

    private void OnDestroy()
    {
        instance = null;
    }
}