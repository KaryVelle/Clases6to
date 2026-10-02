using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private string id; 
    public string Id => id;

    public event Action<Key> OnCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        OnCollected?.Invoke(this);
        gameObject.SetActive(false);
    }
}