using System;

namespace Redmond.SharedKernel.Dtos
{
    public class OperationResult
    {
        public OperationResult()
        {
        }

        public OperationResult(Guid entityId)
        {
            this.EntityId = entityId;
        }

        public OperationResult(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        public OperationResult(bool notFound)
        {
            this.NotFound = notFound;
        }
        
        public Guid? EntityId { get; set; }

        public string ErrorMessage { get; set; }

        public bool NotFound { get; set; }
    }
}
