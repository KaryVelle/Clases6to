using System.Collections.Generic;

public interface ISaveSystem
{
    void SaveKeys(IEnumerable<string> ids);
    HashSet<string> LoadKeys();
}