#pragma checksum "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f99c9795a4c096489c85680e2b2c5641e61e9b12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutMenu), @"mvc.1.0.view", @"/Views/Shared/_LayoutMenu.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\_ViewImports.cshtml"
using SmartReservation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\_ViewImports.cshtml"
using SmartReservation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f99c9795a4c096489c85680e2b2c5641e61e9b12", @"/Views/Shared/_LayoutMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f004aab76d2bdcda1a240deaf080d712866ff5de", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__LayoutMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"navbar-nav-wrap-content-left collapse navbar-collapse\" id=\"navbarNavMenu\">\r\n    <div class=\"navbar-body\">\r\n        <ul class=\"navbar-nav flex-grow-1\">\r\n");
#nullable restore
#line 4 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
               
                var role = User.IsInRole("Admin");

                var name = User.Identity.Name;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
             if (User.IsInRole("Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <!-- Pages -->
                <li class=""hs-has-sub-menu"">
                    <a id=""pagesDropdown"" class=""hs-mega-menu-invoker navbar-nav-link nav-link nav-link-toggle"" href=""javascript:;"" aria-haspopup=""true"" aria-expanded=""false"" aria-labelledby=""navLinkPagesDropdown-Users"">
                        <i class=""fas fa-house nav-icon""></i> Recipes
                    </a>

                    <!-- Dropdown -->
                    <ul id=""navLinkPagesDropdown-Users"" class=""hs-sub-menu dropdown-menu dropdown-menu-lg hs-sub-menu-desktop-lg animated"" aria-labelledby=""pagesDropdown-Users"" style=""min-width: 16rem; animation-duration: 300ms;"">
                        <li>
                            <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 1107, "\"", 1148, 1);
#nullable restore
#line 20 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 1114, Url.Action("Newrecipe", "Recipe"), 1114, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <span class=\"tio-circle-outlined nav-indicator-icon\"></span> New\r\n                            </a>\r\n                        </li>\r\n                        <li>\r\n                            <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 1397, "\"", 1443, 1);
#nullable restore
#line 25 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 1404, Url.Action("Currentrecipes", "Recipe"), 1404, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                <span class=""tio-circle-outlined nav-indicator-icon""></span> View Recipes
                            </a>
                        </li>
                    </ul>
                    <!-- End Dropdown -->
                </li>
");
#nullable restore
#line 32 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <li class=""hs-has-sub-menu"">
                    <a id=""pagesDropdown"" class=""hs-mega-menu-invoker navbar-nav-link nav-link nav-link-toggle"" href=""javascript:;"" aria-haspopup=""true"" aria-expanded=""false"" aria-labelledby=""navLinkPagesDropdown-Users"">
                        <i class=""fas fa-user nav-icon""></i> Recipes
                    </a>

                    <!-- Dropdown -->
                    <ul id=""navLinkPagesDropdown-Users"" class=""hs-sub-menu dropdown-menu dropdown-menu-lg hs-sub-menu-desktop-lg animated"" aria-labelledby=""pagesDropdown-Users"" style=""min-width: 16rem; animation-duration: 300ms;"">
                        <li>
                            <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 2479, "\"", 2525, 1);
#nullable restore
#line 43 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
WriteAttributeValue("", 2486, Url.Action("Currentrecipes", "Recipe"), 2486, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                <span class=""tio-circle-outlined nav-indicator-icon""></span> View Recipes
                            </a>
                        </li>
                    </ul>
                    <!-- End Dropdown -->
                </li>
");
#nullable restore
#line 50 "C:\Users\zaino\Documents\Visual Studio 2019\Projects\No Logo Studios\SmartReservations.Web\SmartReservation\Views\Shared\_LayoutMenu.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
