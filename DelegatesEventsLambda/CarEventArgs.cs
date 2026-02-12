using System;

namespace DelegatesEventsLambda;

public class CarEventArgs:EventArgs
{
    public readonly string msg;
    public CarEventArgs(string s)
    {
        msg = s;
    }
}
