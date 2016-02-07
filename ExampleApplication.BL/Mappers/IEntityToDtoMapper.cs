namespace ExampleApplication.BL.Mappers
{
    /// <summary>
    /// Maps from an entity to its DTO equivalent.
    /// </summary>
    /// <typeparam name="TEntity">Database entity</typeparam>
    /// <typeparam name="TDto">Business logic data transfer object</typeparam>
    public interface IEntityToDtoMapper<in TEntity, out TDto>
    {
        /// <summary>
        /// The mapping method.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="TDto"/>.</returns>
        TDto Map(TEntity entity);
    }
}