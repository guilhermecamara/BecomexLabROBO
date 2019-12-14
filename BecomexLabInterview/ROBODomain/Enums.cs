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
        RotationOf90Degrees,
        RotationOf45Degrees,
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
