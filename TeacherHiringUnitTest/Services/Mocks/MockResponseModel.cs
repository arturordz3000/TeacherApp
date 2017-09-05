using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiringUnitTest.Services.Mocks
{
    public class MockResponseModel
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public MockSubResponseModel Property3 { get; set; }
    }

    public class MockSubResponseModel
    {
        public int SubProperty1 { get; set; }
    }
}
