using System;

public interface IKeyProgress
{
    event Action<int, int> OnKeyCountChanged;
    event Action OnAllKeysCollected;
}