using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

/// <summary>
/// A marker interface that simply indicates that a service should be
/// retrievable via the DependencyService. 
/// </summary>
public interface IManager { }

/// <summary>
/// The dependency manager will manage all our dependencies using a list to register
/// Managers under their interfaces and then retrieving them over a single static method.
/// 
/// The object itself will be used as a singleton but access is managed via a single public static method to retrieve any
/// registered manager interface.
/// </summary>
public class DependencyManager : MonoBehaviour
{
    #region Singleton
    private static DependencyManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private List<GameObject> dependencies = new();

    private Dictionary<Type, object> cache;

    public void Start() => Init();
    private void Init()
    {
        if (cache != null) { return; }

        cache = new();


        foreach (var behaviour in dependencies.Where(entry => entry != null)
                .Select(etnry => etnry.TryGetComponent<MonoBehaviour>(out var behaviour) ? behaviour : null)
                .Where(behaviour => behaviour != null))
        {
            foreach (var iface in behaviour.GetType()
                .GetInterfaces()
                .Where(type => type != typeof(IManager))
                .Where(type => !cache.ContainsKey(type)))
            {
                cache[iface] = behaviour;
            }
        }
    }

    public static bool TryGet<T>([NotNullWhen(true)] out T result) where T : IManager
    {
        if (Instance.cache != null && Instance.cache.TryGetValue(typeof(T), out var value))
        {
            result = (T)value;
            return true;
        }

        result = default;
        return false;
    }
}