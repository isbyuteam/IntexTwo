using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using IntexTwo.Models;
using IntexTwo.Models.ViewModels;

namespace aspnetcore.Controllers
{
    public class InferenceController : Controller
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }
        [HttpGet]
        public IActionResult Calculator ()
        {
            return View();
        }


        [HttpPost]
       public IActionResult Result (CrashSeverityData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<float> score = result.First().AsTensor<float>();
            var prediction = new Prediction { PredictedValue = score.First()};
            result.Dispose();
            ViewBag.Result = prediction.PredictedValue;
            return View(prediction);
        }
    }
}

