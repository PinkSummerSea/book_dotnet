using System;

namespace CustomInterfaces;

public interface IPointy
{
    // implicitly public and abstract
    //byte GetNumberOfPoints();
    byte Points { get; }
}
