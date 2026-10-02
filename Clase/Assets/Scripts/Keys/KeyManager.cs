using System;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class KeyManager : MonoBehaviour, IKeyProgress
{
    [SerializeField] private int totalKeys = 5;

    public event Action<int, int> OnKeyCountChanged;
    public event Action OnAllKeysCollected;

    private HashSet<string> idsRecolectados;
    private ISaveSystem saveSystem;
    private readonly List<Key> llavesSuscritas = new List<Key>();

    private void Awake()
    {
        saveSystem = new SaveSystem();
        idsRecolectados = saveSystem.LoadKeys();
    }

    private void Start()
    {
        Key[] llavesEnEscena = FindObjectsByType<Key>(FindObjectsSortMode.None);
        HashSet<string> idsVistos = new HashSet<string>();

        foreach (Key llave in llavesEnEscena)
        {
            if (string.IsNullOrEmpty(llave.Id))
                Debug.LogWarning($"La llave '{llave.name}' no tiene ID.", llave);
            else if (!idsVistos.Add(llave.Id))
                Debug.LogWarning($"El ID '{llave.Id}' está repetido.", llave);

            if (idsRecolectados.Contains(llave.Id))
            {
                llave.gameObject.SetActive(false);
                continue;
            }

            llave.OnCollected += HandleKeyCollected;
            llavesSuscritas.Add(llave);
        }

        NotificarCambio();
    }

    private void OnDisable()
    {
        foreach (Key llave in llavesSuscritas)
        {
            if (llave != null)
                llave.OnCollected -= HandleKeyCollected;
        }
    }

    private void HandleKeyCollected(Key llave)
    {
        llave.OnCollected -= HandleKeyCollected;
        llavesSuscritas.Remove(llave);

        idsRecolectados.Add(llave.Id);
        saveSystem.SaveKeys(idsRecolectados);
        NotificarCambio();
    }

    public void ResetProgreso()
    {
        idsRecolectados.Clear();
        saveSystem.SaveKeys(idsRecolectados);
        NotificarCambio();
    }

    private void NotificarCambio()
    {
        int cantidad = idsRecolectados.Count;
        OnKeyCountChanged?.Invoke(cantidad, totalKeys);

        if (cantidad >= totalKeys)
            OnAllKeysCollected?.Invoke();
    }
}