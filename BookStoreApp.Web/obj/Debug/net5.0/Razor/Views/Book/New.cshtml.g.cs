#pragma checksum "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\Book\New.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "af29af48a8fe9e5c001bd0022861b5508de87a8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_New), @"mvc.1.0.view", @"/Views/Book/New.cshtml")]
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
#line 1 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\_ViewImports.cshtml"
using BookStoreApp.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\_ViewImports.cshtml"
using BookStoreApp.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\_ViewImports.cshtml"
using BookStoreApp.Models.DTOs.VM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af29af48a8fe9e5c001bd0022861b5508de87a8e", @"/Views/Book/New.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74e4bbee3e89953a5b1e77387c783400e1552023", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_New : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\Book\New.cshtml"
   ViewData["Title"] = "Add a book"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\Book\New.cshtml"
   ViewBag.IsNew = true;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 7 "C:\Users\elena\Pictures\MASTER\BookStoreApp\BookStoreApp.Web\Views\Book\New.cshtml"
Write(await Html.PartialAsync(@"../Shared/Components/_Book.cshtml"));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
