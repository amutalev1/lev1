using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Seldat.Amuta.Entities.Validations
{
    public class ValidateModel
    {
        public static List<ValidationResult> ModelsResults;
        public static bool IsValid(List<object> models)
        {
            var isValidModels = true;
            ModelsResults = new List<ValidationResult>();
            foreach (var model in models)
            {
                if (model != null)
                {
                    var context = new ValidationContext(model);
                    var results = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(model, context, results, true);
                    ModelsResults.AddRange(results);
                    if (!isValid)
                        isValidModels = false;
                }
            }

            if (!isValidModels)
                return false;
            return true;
        }
    }

}
