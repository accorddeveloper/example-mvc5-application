namespace ExampleApplication.BDD
{
    using System;

    using NUnit.Framework;

    /// <summary>
    /// What happens after an action has been performed.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ThenAttribute : TestAttribute
    {
    }
}