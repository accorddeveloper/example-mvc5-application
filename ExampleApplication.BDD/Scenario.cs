namespace ExampleApplication.BDD
{
    using NUnit.Framework;

    /// <summary>
    /// A BDD scenario for something happening.
    /// </summary>
    [TestFixture]
    public abstract class Scenario
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Scenario"/> class. Executes the Given method.
        /// </summary>
        protected Scenario()
        {
            Given();
        }

        /// <summary>
        /// Given certain conditions.
        /// </summary>
        protected abstract void Given();

        /// <summary>
        /// When an action has been peformed.
        /// </summary>
        [OneTimeSetUp]
        protected abstract void When();

    }
}