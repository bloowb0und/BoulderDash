using System;
using System.Collections.Generic;

namespace BoulderDash
{
    public interface IField
    {
        void Draw();
        void SaveToJson(string fileName, List<Diamond> diamonds, List<Stone> stones, Player player);
    }
}