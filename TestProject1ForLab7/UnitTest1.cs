using lab6oopvn;
using Microsoft.VisualStudio.TestPlatform.TestHost;
namespace TestProject1ForLab7
{
    //[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
    // dotnet test 'D:\lab6oopvn\TestProject1ForLab7\bin\Debug\net8.0\TestProject1ForLab7.dll'
    // dotnet test 'D:\lab6oopvn\TestProject1ForLab7\bin\Debug\net8.0\TestProject1ForLab7.dll' --test-adapter-path NUnit3.TestAdapter.dll
    [TestFixture]
    public class MyDelTests
    {
        [TestCase(new int[] { 99, -77, 3, 4, -6 }, 4.6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3.0)]
        [TestCase(new int[] { -5, 0, 5}, 0.0)]
        [TestCase(new int[] { -5, -7, -9 },-7.0)]
        [TestCase(new int[] { 1000000, 2000000, 3000000 }, 2000000.0)]
        [TestCase(new int[] { 42 }, 42.0)]
        [TestCase(new int[] { 1, 2, 8 }, 11.0 / 3.0)]
        [TestCase(new int[] { 0, 0, 0 }, 0.0)]
        public void ReturnsCorrectAverage(int[] arr, double expected)
        {
            double result = ClassDelegate.avgResult(arr);
            Assert.That(result, Is.EqualTo(expected).Within(1e-10));
        }

        [Test]
        public void Average_EmptyArray_ThrowsArgumentException()
        {
            int[] arr = Array.Empty<int>();
            Assert.That(() => ClassDelegate.avgResult(arr), Throws.ArgumentException);
        }

        [Test]
        public void Average_NullArray_ThrowsArgumentException()
        {
            int[] arr = null;
            Assert.That(() => ClassDelegate.avgResult(arr), Throws.ArgumentException);
        }
    }
}


