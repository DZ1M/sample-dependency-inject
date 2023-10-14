using sample_dependency_inject.Models;

namespace sample_dependency_inject.Services
{
    public class TestServiceTransient
    {
        private readonly ObjectSampleTransient _objectTransient;
        public TestServiceTransient(ObjectSampleTransient objectTransient)
        {
            _objectTransient = objectTransient;
        }

        public int GetCounter()
            => _objectTransient.Counter;
    }
}
