using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace HaberSitesiASP.Helpers.Exceptions
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        IWebHostEnvironment _environment;
        IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilterAttribute() { }

        public CustomExceptionFilterAttribute(IWebHostEnvironment environment, IModelMetadataProvider provider)
        {
            _environment = environment;
            _modelMetadataProvider = provider;
        }
        public override void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
                return;

            context.ExceptionHandled = true;
            var errorFolderPath = Path.Combine(_environment.WebRootPath, "ErrorLogs");

            if (!Directory.Exists(errorFolderPath))
            {
                Directory.CreateDirectory(errorFolderPath);
            }
            string timeStamp = DateTime.Now.ToString("d-MMMM-yyyy", CultureInfo.InvariantCulture);
            string newFileName = $"Log_{timeStamp}.txt";
            string filePath = Path.Combine(_environment.WebRootPath, "ErrorLogs", newFileName);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Message----\n" + context.Exception.Message);
            stringBuilder.AppendLine("Source----\n" + context.Exception.Source);
            stringBuilder.AppendLine("StackTrace----\n" + context.Exception.StackTrace);
            stringBuilder.AppendLine("TargetSite----\n" + context.Exception.TargetSite);

            FileLog(filePath, stringBuilder, context);

            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            context.Result = result;
        }
        private void FileLog(string filePath, Object obje, ExceptionContext context)
        {
            if (!File.Exists(filePath))
            {
                using (var writer = File.CreateText(filePath))
                {
                    var controllerName = context.RouteData.Values["Controller"];
                    var actionName = context.RouteData.Values["Action"];
                    writer.WriteLine($"ControllerName : {controllerName}");
                    writer.WriteLine($"ActionName : {actionName}");
                    writer.WriteLine("Exception");
                    writer.WriteLine(obje);
                    writer.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                using (var writer = File.AppendText(filePath))
                {
                    var controllerName = context.RouteData.Values["controller"];
                    var actionName = context.RouteData.Values["action"];
                    writer.WriteLine($"ControllerName : {controllerName}");
                    writer.WriteLine($"ActionName : {actionName}");
                    writer.WriteLine("Exception");
                    writer.WriteLine(obje);
                    writer.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                }
            }
        }
    }
}
