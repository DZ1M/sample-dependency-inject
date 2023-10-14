using Microsoft.AspNetCore.Mvc;
using sample_dependency_inject.Models;
using sample_dependency_inject.Services;

namespace sample_dependency_inject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InjectDependencyController : ControllerBase
    {
        private readonly ObjectSampleSingleton _objectSampleSingleton;
        private readonly ObjectSampleScoped _objectSampleScoped;
        private readonly ObjectSampleTransient _objectSampleTransient;
        private readonly TestServiceTransient _testServiceTransient;
        public InjectDependencyController(
            ObjectSampleSingleton objectSampleSingleton,
            ObjectSampleScoped objectSampleScoped,
            ObjectSampleTransient objectSampleTransient,
            TestServiceTransient testServiceTransient)
        {
            _objectSampleSingleton = objectSampleSingleton;
            _objectSampleScoped = objectSampleScoped;
            _objectSampleTransient = objectSampleTransient;
            _testServiceTransient = testServiceTransient;
        }

        [HttpGet(Name = "TestDI")]
        public IActionResult Test()
        {
            _objectSampleSingleton.Counter++;

            _objectSampleScoped.Counter++;

            _objectSampleTransient.Counter++;

            return Ok(new 
            {
                singleton = _objectSampleSingleton.Counter,
                scopped = _objectSampleScoped.Counter,
                transient = _objectSampleTransient.Counter,
                transientService = _testServiceTransient.GetCounter()
            });
        }
    }
}