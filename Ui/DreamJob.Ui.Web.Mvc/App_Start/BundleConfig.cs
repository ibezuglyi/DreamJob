using System.Web;
using System.Web.Optimization;

namespace DreamJob.Ui.Web.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/site")
                .Include("~/Content/Site.css")
                .Include("~/Scripts/loading-bar.min.css"));

            bundles.Add(Foundation.Styles());
            bundles.Add(Foundation.Scripts());

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/AngularApplication/LocalizationTexts.js")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-route.js")
                .Include("~/Scripts/loading-bar.min.js")
                .Include("~/Scripts/foundation-angular/mm-foundation-tpls-0.3.1.min.js")
                .Include("~/AngularApplication/dreamjobapplication.js")
                .Include("~/AngularApplication/Controllers/ProfileController.js")
                .Include("~/AngularApplication/Controllers/OffersController.js")
                .Include("~/AngularApplication/Controllers/AcceptOfferController.js")
                .Include("~/AngularApplication/Controllers/DevelopersSearchController.js")
                .Include("~/AngularApplication/Services/DreamJobApiClient.js")
                .Include("~/AngularApplication/Services/SearchViewModelService.js")
                .Include("~/AngularApplication/Validators/priceValidator.js")
                
                .Include("~/AngularApplication/Controllers/RecruiterPanelController.js")
                .Include("~/AngularApplication/Controllers/RecruiterPanelJobEditorController.js"));
        }
    }
}