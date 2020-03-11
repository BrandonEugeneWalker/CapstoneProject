using System.Data.Entity.Core.Objects;

namespace Capstone_Unit_Tests.web_members
{
    /// <summary>
    ///     Overriding class for testing with ObjectResults, as its constructor is protected
    ///     Used in mocking Stored Procedure returns, setting to an object type or list of objects
    /// </summary>
    /// <typeparam name="T">Mocked Object Result Type</typeparam>
    /// <seealso cref="ObjectResult{T}" />
    public class TestableObjectResult<T> : ObjectResult<T>
    {
    }
}