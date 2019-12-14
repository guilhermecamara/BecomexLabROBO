using System;
using System.Collections.Generic;
using System.Text;

namespace ROBODomain
{
    public enum StateEnum 
    { 
        Resting,
        SlighlyContracted,
        Contracted,
        StronglyContracted,
        RotationOfMinus90Degrees,
        RotationOfMinus45Degrees,
        RotationOf45Degrees,
        RotationOf90Degrees,        
        RotationOf135Degrees,
        RotationOf180Degrees,
        Upwards,
        Downwards
    }

    public enum BodySideEnum
    { 
        Right,
        Left
    }
}
