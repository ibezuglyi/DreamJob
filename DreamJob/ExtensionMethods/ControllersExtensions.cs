using System.IO;
using System.Web.Mvc;

namespace DreamJob.ExtensionMethods
{
    public static class ControllersExtensions
    {
        public static string ViewAsString(this Controller controller, string viewPath, object model)
        {
            var viewEngineResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewPath, null);
            var renderToView = RenderToView(controller, model, viewEngineResult);
            return renderToView;
        }

        public static string PartialViewAsString(this Controller controller, string viewPath, object model)
        {
            var viewEngineResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewPath);
            var partialViewAsString = RenderToView(controller, model, viewEngineResult);
            return partialViewAsString;
        }

        private static string RenderToView(Controller controller, object model, ViewEngineResult viewEngineResult)
        {
            var view = viewEngineResult.View;
            controller.ViewData.Model = model;

            string result;

            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(
                    controller.ControllerContext,
                    view,
                    controller.ControllerContext.Controller.ViewData,
                    controller.TempData,
                    sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}