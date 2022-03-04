using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Model
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }
    
}
