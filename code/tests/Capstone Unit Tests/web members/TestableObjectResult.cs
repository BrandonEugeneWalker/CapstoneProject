using System.Data.Entity.Core.Objects;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    /// Overriding class for testing with ObjectResults, as its constructor is protected
    /// </summary>
    /// <typeparam name="T">Generic Object</typeparam>
    /// <seealso cref="System.Data.Entity.Core.Objects.ObjectResult{T}" />
    public class TestableObjectResult<T> : ObjectResult<T>
    {
    }
}
