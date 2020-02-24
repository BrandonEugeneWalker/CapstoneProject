using System.Data.Entity.Core.Objects;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    /// Overriding class for testing with ObjectResults
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Data.Entity.Core.Objects.ObjectResult{T}" />
    public class TestableObjectResult<T> : ObjectResult<T>
    {
    }
}
