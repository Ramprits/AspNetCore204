using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreApplication.Helper {
    public class UnprocessableEntityObjectResult : ObjectResult {
        public UnprocessableEntityObjectResult (ModelStateDictionary modelState) : base (new SerializableError (modelState)) {
            if (modelState == null) {
                throw new System.ArgumentNullException (nameof (modelState));
            }
            StatusCode = 422;
        }
    }
}