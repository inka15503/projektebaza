#pragma checksum "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d515e71507b543870b208386e6e7c95f1976165"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Categories_ListCategories), @"mvc.1.0.view", @"/Views/Dashboard/Categories/ListCategories.cshtml")]
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
#line 1 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\_ViewImports.cshtml"
using PROJEKTU_SKRYPTU_EBAZA;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\_ViewImports.cshtml"
using PROJEKTU_SKRYPTU_EBAZA.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\_ViewImports.cshtml"
using PROJEKTU_SKRYPTU_EBAZA.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d515e71507b543870b208386e6e7c95f1976165", @"/Views/Dashboard/Categories/ListCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6350f1b1b019bfeef3fcc02ba6c0157644d829b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Dashboard_Categories_ListCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductCategory>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
  
    ViewData["Title"] = "Lista Kategorii";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-12\">\r\n        <h1>Tutaj znajdziesz listę wszystkich kategorii</h1>\r\n    </div>\r\n</div>\r\n<a");
            BeginWriteAttribute("href", " href=\"", 214, "\"", 247, 1);
#nullable restore
#line 12 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
WriteAttributeValue("", 221, Url.Action("AddCategory"), 221, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary my-3"">Dodaj Kategorie</a>
<div class=""card"">
    <div class=""card-body"">

        <div class=""text-center"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th scope=""col"">Nazwa</th>
                        <th scope=""col"">Ilość produktów</th>
                        <th>Edytuj</th>
                        <th>Usuń</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 27 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <th scope=\"row\">");
#nullable restore
#line 30 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
                       Write(item.Products.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 992, "\"", 1044, 1);
#nullable restore
#line 32 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
WriteAttributeValue("", 999, Url.Action("EditCategory", new {id=item.Id}), 999, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa-solid fa-pen-to-square text-success\"></i></a></td>\r\n                        <td>\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d515e71507b543870b208386e6e7c95f19761657253", async() => {
                WriteLiteral("\r\n                                <button type=\"submit\" class=\"btn-remove\"> <i class=\"fa-solid fa-trash  text-danger\"></i></button>\r\n\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 35 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
                                                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                          \r\n                        </td>\r\n\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 45 "C:\Users\Luki\source\repos\PROJEKTU SKRYPTU EBAZA\PROJEKTU SKRYPTU EBAZA\Views\Dashboard\Categories\ListCategories.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductCategory>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
