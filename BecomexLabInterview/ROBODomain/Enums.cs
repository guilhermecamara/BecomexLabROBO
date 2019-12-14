using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ROBO.Core
{
    public enum StateEnum
    {
        Resting,
        [Description("Slighly contracted")]
        SlighlyContracted,
        Contracted,
        [Description("Strongly contracted")]
        StronglyContracted,
        [Description("Rotation of -90º")]
        RotationOfMinus90Degrees,
        [Description("Rotation of -45º")]
        RotationOfMinus45Degrees,
        [Description("Rotation of 45º")]
        RotationOf45Degrees,
        [Description("Rotation of 90º")]
        RotationOf90Degrees,
        [Description("Rotation of 135º")]
        RotationOf135Degrees,
        [Description("Rotation of 180º")]
        RotationOf180Degrees,
        Upwards,
        Downwards
    }

    public enum BodySideEnum
    {
        Right,
        Left
    }

    public class Description : Attribute
    {
        public string Text;

        public Description(string text)
        {
            Text = text;
        }
    }

    public static class EnumsExtensions
    {
        public static string GetDescription(this Enum en) {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Description), false);

                if (attrs != null && attrs.Length > 0)
                    return ((Description)attrs[0]).Text;
            }

            return en.ToString("F");
        }
    }
}
