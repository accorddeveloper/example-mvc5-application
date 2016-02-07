namespace ExampleApplication.BDD
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// When happens when an action is performed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ThenAttribute : TestAttribute
    {
    }
}