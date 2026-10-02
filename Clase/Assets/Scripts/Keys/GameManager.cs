using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private KeyManager keyManager;
    [SerializeField] private bool deleteProgress;

    private void Awake()
    {
        if (deleteProgress)
            BorrarPartida();
    }

    public void BorrarPartida()
    {
        keyManager.ResetProgreso();
    }

    public void ReiniciarJuego()
    {
        BorrarPartida();
        ReiniciarEscena();
    }

    public void ReiniciarEscena()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}