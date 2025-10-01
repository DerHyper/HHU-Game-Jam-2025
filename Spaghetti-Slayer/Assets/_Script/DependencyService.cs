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
/// The dependency service will manage all our dependencies using a list to register
/// Managers under their interfaces and then retrieving them over a single static method.
/// 
/// The object itself will be used as a singleton but access is managed via a single public static method to retrieve any
/// registered manager interface.
/// </summary>
[CreateAssetMenu(fileName = "DependencyManager", menuName = "Systems/Dependency Manager")]
public class DependencyService : ScriptableObject
{
    #region Singleton
    private static DependencyService Instance { get; set; }
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


    [Serializable]
    private struct DependencyEntry
    {
        public UnityEngine.Object implementation;
    }

    [SerializeField] private List<DependencyEntry> dependencies = new();

    private Dictionary<Type, object> cache;

    public void Start() => Init();

    private void Init()
    {
        cache = new();
        foreach (var entry in dependencies)
        {
            if (entry.implementation == null) { continue; }

            foreach (var iface in entry.implementation.GetType()
                                       .GetInterfaces()
                                       .Where(type => type != typeof(IManager))
                                       .Where(type => !cache.ContainsKey(type)))
            {
                cache[iface] = entry.implementation;
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