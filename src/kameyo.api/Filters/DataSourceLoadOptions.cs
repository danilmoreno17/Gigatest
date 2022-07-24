using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kameyo.Api.Filters
{
    [ModelBinder(typeof(DataSourceLoadOptionsHttpBinder))]
    public class DataSourceLoadOptions : DataSourceLoadOptionsBase { }

    class DataSourceLoadOptionsHttpBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var loadOptions = new DataSourceLoadOptions();


            //DataSourceLoadOptionsParser.Parse(loadOptions, key => bindingContext.ValueProvider.GetValue(key).ToDictionary<string,string>());

            DataSourceLoadOptionsParser.Parse(loadOptions, key =>
            {
                var data = bindingContext.HttpContext.Request.Query;
                var result = data.TryGetValue(key, out var value);
                string? resultData = string.Empty;

                if (result)
                {
                    resultData = value;
                }

                return resultData;                
            });

            bindingContext.Result = ModelBindingResult.Success(loadOptions);
            bindingContext.Model = loadOptions;

            return Task.CompletedTask;
        }
    }
}