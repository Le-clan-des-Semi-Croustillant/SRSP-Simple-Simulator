using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Communication.DataProcessing.Json;

namespace Model
{
    /// <summary>
    /// Interface of an observer pattern
    /// </summary>
    public interface IObserver
    {
        void Update(ISubject subject);

    }
    
}
