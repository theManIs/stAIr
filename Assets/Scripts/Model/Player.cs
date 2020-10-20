using Model;
using System.Collections.Generic;
using System.Linq;

class Player
{
    public static Player Instance;

    static Player()
    {
        Instance = new Player();    
    }

    /// <summary>Units of Player</summary>
    public List<Unit> Units = new List<Unit>();

    /// <summary>Is there any unit with module?</summary>
    public bool HasModule(string moduleName)
    {
        return Units.Any(u=>u.Modules.Any(m=>m.Name == moduleName));
    }
}