using Microsoft.AspNetCore.Mvc;
using Redmond.SharedKernel.Dtos;

namespace Redmond.API.Helpers
{
    public static class ControllerHelper
    {
        public static IActionResult SwitchResult(this ControllerBase controller, object result)
        {
            if (result == null)
            {
                return controller.NotFound();
            }

            if (result is OperationResult operationResult)
            {
                return SwitchOperationResult(controller, operationResult);
            }

            return controller.Ok(result);
        }

        private static IActionResult SwitchOperationResult(ControllerBase controller, OperationResult operationResult)
        {
            if (operationResult.NotFound)
            {
                return controller.NotFound();
            }

            if (!string.IsNullOrWhiteSpace(operationResult.ErrorMessage))
            {
                return controller.BadRequest(operationResult.ErrorMessage);
            }

            if (operationResult.EntityId.HasValue)
            {
                return controller.Ok(operationResult.EntityId);
            }

            return controller.NoContent();
        }
    }
}
