using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
									"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
									"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
									"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
								"~/Scripts/bootstrap.js"));

#region SignalR Bundles
			bundles.Add(new ScriptBundle("~/bundles/signalR-v1").Include(
								"~/Scripts/asp.net-signalR/jquery.signalR-2.4.3.min.js",
								"~/Scripts/asp.net-signalR/hubs-configuration.js"));

			bundles.Add(new ScriptBundle("~/bundles/signalR-v2").Include(
					"~/Scripts/core-old-signalR/signalr.js"));

			bundles.Add(new ScriptBundle("~/bundles/signalR-v3").Include(
					"~/Scripts/core-current-signalR/signalr.js"));
#endregion

			bundles.Add(new StyleBundle("~/Content/css").Include(
											"~/Content/bootstrap.css",
											"~/Content/site.css"));
		}
	}
}
