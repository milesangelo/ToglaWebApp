using System.Collections.Generic;

namespace Togla.Utilities.DataImporter
{
    public interface ICsvParser
    {
        public List<T> Parse<T>();
    }
}