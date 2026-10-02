using UnityEngine;

public class EndGameSystem : MonoBehaviour
{
    [SerializeField] private Canvas endGameCanvas;

    private void Awake()
    {
        // 1. Deja el menú oculto al iniciar
    }

    private void OnTriggerEnter(Collider other)
    {
        // 2. Si no es el Player, no hagas nada
        // 3. Muestra el menú
        // 4. Detén el juego
        // 5. Haz desaparecer el objeto dorado
        // 6. WUUUUUUUU
    }
}