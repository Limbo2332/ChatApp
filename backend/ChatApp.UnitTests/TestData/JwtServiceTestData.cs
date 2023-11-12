using System.Collections;

namespace ChatApp.UnitTests.TestData
{
    public class JwtServiceTestData : TheoryData<int, string, string>
    {
        public JwtServiceTestData()
        {
            Add(1, "test", "test@gmail.com");
            Add(2, "unique", "unique@gmail.com");
            Add(3, "helloWorld!", "my@gmail.com");
            Add(4, "cmon", "test@hotline.com");
            Add(5, "MyUserName", "mypost@gmail.com");
        }
    }
}
