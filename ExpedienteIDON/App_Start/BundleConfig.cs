using System.Web;
using System.Web.Optimization;

namespace ExpedienteIDON
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Scripts/theme/plugins/bootstrap/css/bootstrap.min.css",
                        "~/Scripts/theme/css/style.css",
                        "~/Scripts/theme/css/plugins.min.css",
                        "~/Scripts/theme/css/responsive.css",
                        "~/Scripts/theme/css/theme-color.css",
                        "~/Scripts/theme/plugins/material/material.min.css",
                        "~/Scripts/theme/css/material_style.css",
                        "~/Scripts/theme/fonts/font-awesome/css/font-awesome.min.css",
                        "~/Scripts/theme/plugins/bootstrap-datetimepicker/css/bootstrap-datetimepicker.min.css",
                        "~/Scripts/theme/plugins/bootstrap-colorpicker/css/bootstrap-colorpicker.css",
                        "~/Scripts/theme/plugins/material/material.min.css",
                        "~/Scripts/theme/css/material_style.css",
                        "~/Scripts/theme/css/pages/formlayout.css",
                        "~/Scripts/theme/plugins/dropzone/dropzone.css",
                        "~/Scripts/theme/plugins/jquery-tags-input/jquery-tags-input.css",
                        "~/Scripts/theme/plugins/select2/css/select2.css",
                        "~/Scripts/theme/plugins/select2/css/select2-bootstrap.min.css"));
        }
    }
}
