using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Environement;



using System;

class TestClass
{
    static void Main(string[] args)
    {
        var env = new Environement.Environment();
        Dictionary<Conditions, float> envState = new Dictionary<Conditions, float>();
        env.UpdateCurrent(17, 24.9F);

        float[] expect = new float[] { 0, 0, 17, 24.9F, 0, 0, 0 };
        var conds = Enum.GetValues(typeof(Conditions));
        float[] value = new float[7];
        int i = 0;
        foreach (Conditions cond in conds)
        {
            envState.TryGetValue(cond, out value[i]);
            i++;
        }
        Console.WriteLine(expect);
        Console.WriteLine(value);
    }
}
