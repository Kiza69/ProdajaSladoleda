#pragma checksum "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e827a077695af2bdc70a1272786c045b04b89a90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Categories_Details), @"mvc.1.0.view", @"/Views/Categories/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Categories/Details.cshtml", typeof(AspNetCore.Views_Categories_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e827a077695af2bdc70a1272786c045b04b89a90", @"/Views/Categories/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1a2867d427831583d00e3f9ae1a2cabe8b362bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Categories_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProdajaSladoleda.Application.DataTransfer.CategoryDtos.CategoryDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
  
    ViewData["Title"] = "Detalji kategorije";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(178, 125, true);
            WriteLiteral("\r\n    <h2>Detalji kategorije proizvoda:</h2>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(304, 46, false);
#line 14 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(350, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(394, 42, false);
#line 17 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayFor(model => model.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(436, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(480, 40, false);
#line 20 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(520, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(564, 36, false);
#line 23 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(600, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(644, 41, false);
#line 26 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(685, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(729, 37, false);
#line 29 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(766, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(810, 42, false);
#line 32 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
            EndContext();
            BeginContext(852, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(896, 38, false);
#line 35 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
       Write(Html.DisplayFor(model => model.Active));

#line default
#line hidden
            EndContext();
            BeginContext(934, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(982, 62, false);
#line 40 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.CategoryId }));

#line default
#line hidden
            EndContext();
            BeginContext(1044, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1052, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "45d2563f16e044ba85fcf7260945ffcf", async() => {
                BeginContext(1074, 12, true);
                WriteLiteral("Back to List");
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
            BeginContext(1090, 185, true);
            WriteLiteral("\r\n</div>\r\n<div>\r\n    <br />\r\n    <br />\r\n    <h4>Proizvodi ove kategorije:</h4>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1276, 40, false);
#line 51 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1316, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1384, 42, false);
#line 54 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
               Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
            EndContext();
            BeginContext(1426, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 60 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
             foreach (var item in Model.Products)
            {

#line default
#line hidden
            BeginContext(1598, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1671, 39, false);
#line 64 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1710, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1790, 41, false);
#line 67 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
            EndContext();
            BeginContext(1831, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 70 "D:\Skola\III godina\III trimestar\ASP\Prodaja sladoleda projekat\ProdajaSladoleda\WEB\Views\Categories\Details.cshtml"
            }

#line default
#line hidden
            BeginContext(1898, 37, true);
            WriteLiteral("        <tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProdajaSladoleda.Application.DataTransfer.CategoryDtos.CategoryDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
