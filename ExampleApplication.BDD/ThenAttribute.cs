namespace ExampleApplication.BDD
{
    using NUnit.Framework;
    using System;

    /// <summary>
    /// When happens when an action is performed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ThenAttribute : TestAttribute
    {
    }
}