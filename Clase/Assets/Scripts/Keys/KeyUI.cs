using TMPro;
using UnityEngine;

public class KeyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textKeys;

    private IKeyProgress progress;

    private void Awake()
    {
        // 1. Busca el KeyManager en la escena y guárdalo en progress
    }

    private void OnEnable()
    {
        // 2. Suscríbete a OnKeyCountChanged
    }

    private void OnDisable()
    {
        // 3. Desuscríbete
    }

    private void ActualizarTexto(int x, int y)
    {
        // 4. Escribe el texto "Llaves: X/Y"
    }
}