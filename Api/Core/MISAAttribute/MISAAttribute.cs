﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Web07.Core.MISAAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISANotMap : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string Name = string.Empty;

        public MISARequired(string name = "")
        {
            Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAEmail : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAPhoneNumber : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAIsNumber : Attribute
    {
        public string Name = string.Empty;

        public MISAIsNumber(string name = "")
        {
            Name = name;
        }
    }
}
