#pragma checksum "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7b661568f0a49dc24e37fc7d35ac4b886f0cfc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Index), @"mvc.1.0.view", @"/Views/Categories/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Index.cshtml", typeof(AspNetCore.Views_Categories_Index))]
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
#line 1 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\_ViewImports.cshtml"
using WEB;

#line default
#line hidden
#line 2 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\_ViewImports.cshtml"
using WEB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7b661568f0a49dc24e37fc7d35ac4b886f0cfc1", @"/Views/Categories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProdajaSladoleda.Application.DataTransfer.CategoryDtos.CategoryDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
  
    ViewData["Title"] = "Kategorije proizvoda";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(193, 49, true);
            WriteLiteral("\r\n    <h2>Kategorije proizvoda:</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(242, 48, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea3d82fab6d64e829c6b562512e4621f", async() => {
                BeginContext(265, 21, true);
                WriteLiteral("Unesi novu kategoriju");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(290, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(383, 46, false);
#line 17 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(429, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(485, 40, false);
#line 20 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(525, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(581, 41, false);
#line 23 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(622, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(678, 42, false);
#line 26 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
            EndContext();
            BeginContext(720, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 32 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(838, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(887, 45, false);
#line 35 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(932, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(988, 39, false);
#line 38 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1027, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1083, 40, false);
#line 41 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1123, 57, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1181, 41, false);
#line 45 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
            EndContext();
            BeginContext(1222, 57, true);
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1280, 61, false);
#line 49 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.CategoryId }));

#line default
#line hidden
            EndContext();
            BeginContext(1341, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1362, 67, false);
#line 50 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.CategoryId }));

#line default
#line hidden
            EndContext();
            BeginContext(1429, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1450, 65, false);
#line 51 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id = item.CategoryId }));

#line default
#line hidden
            EndContext();
            BeginContext(1515, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 54 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1554, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProdajaSladoleda.Application.DataTransfer.CategoryDtos.CategoryDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591