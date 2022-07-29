using System.Collections.Generic;
using BoulderDashClassLibrary.GameElements;

namespace BoulderDashClassLibrary.Interfaces
{
    public interface IField
    {
        void Draw();
        void SaveToJson(string fileName, List<Diamond> diamonds, List<Stone> stones, Player player);
    }
}