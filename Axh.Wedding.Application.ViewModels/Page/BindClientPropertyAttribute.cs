namespace Axh.Wedding.Application.ViewModels.Page
{
    using System;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class BindClientPropertyAttribute : Attribute
    {
        public BindClientPropertyAttribute(string name = null)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
