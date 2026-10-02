using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject puertaVisual;
    [SerializeField] private Collider puertaCollider;

    private IKeyProgress progress;

    private void Awake()
    {
        // 1. Busca el KeyManager
    }

    private void OnEnable()
    {
        // 2. Suscríbete a OnAllKeysCollected
    }

    private void OnDisable()
    {
        // 3. Desuscríbete
    }

    private void AbrirPuerta()
    {
        // 4. Apaga lo visual y desactiva el collider
    }
}