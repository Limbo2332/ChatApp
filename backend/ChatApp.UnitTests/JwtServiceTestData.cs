using System.Collections;

namespace ChatApp.UnitTests
{
    public class JwtServiceTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, "test", "test@gmail.com" };
            yield return new object[] { 2, "unique", "unique@gmail.com" };
            yield return new object[] { 3, "helloWorld!", "my@gmail.com" };
            yield return new object[] { 4, "cmon", "test@hotline.com" };
            yield return new object[] { 5, "MyUserName", "mypost@gmail.com" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
