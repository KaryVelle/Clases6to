using Unity.Cinemachine;
using UnityEngine;

public class CinemachineLook : MonoBehaviour, ILookable
{
    [SerializeField] private CinemachineOrbitalFollow orbitalFollow;
    [SerializeField] private float sensitivity = 0.15f;

    public void Look(Vector2 delta)
    {
        orbitalFollow.HorizontalAxis.Value += delta.x * sensitivity;
        float vertical = orbitalFollow.VerticalAxis.Value - delta.y * sensitivity;
        Vector2 range = orbitalFollow.VerticalAxis.Range;
        orbitalFollow.VerticalAxis.Value = Mathf.Clamp(vertical, range.x, range.y);
    }
}