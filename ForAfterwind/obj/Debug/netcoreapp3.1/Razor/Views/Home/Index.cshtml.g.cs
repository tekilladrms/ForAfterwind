#pragma checksum "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75bac95a3d1bd80be0667024d1136ebe7761d1fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75bac95a3d1bd80be0667024d1136ebe7761d1fd", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ForAfterwind.ViewModels.HomePageViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 5 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
   ViewData["Title"] = "Home"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div");
            BeginWriteAttribute("class", " class=\"", 142, "\"", 150, 0);
            EndWriteAttribute();
            WriteLiteral(">\n");
#nullable restore
#line 8 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
     foreach(var greeting in Model.greetings)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row greeting\">\r\n            <div class=\"col greeting__container\">\n                <h1>");
#nullable restore
#line 12 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
               Write(greeting.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n");
#nullable restore
#line 13 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
                 if (greeting.Cover != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"greeting__image\">\n");
#nullable restore
#line 17 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
                           var base64 = Convert.ToBase64String(greeting.Cover);
                            var imgSrc = String.Format("data:image/gif;base64,{0}", base64); 

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img class=\"post__view-img background__darkest\"");
            BeginWriteAttribute("src", " src=\"", 776, "\"", 789, 1);
#nullable restore
#line 19 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
WriteAttributeValue("", 782, imgSrc, 782, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\n                    </div>\n");
#nullable restore
#line 21 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                \n                <div class=\"greeting__body\">\n                    ");
#nullable restore
#line 24 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
               Write(Html.Raw(greeting.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 29 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n\n\n\n\n");
#nullable restore
#line 35 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
 foreach (var progressBar in Model.progressBars)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row background__dark progress__bar\">\n    <div class=\"col-lg\">\n        <h3 class=\"progress__bar-title\">\n            ");
#nullable restore
#line 40 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
       Write(progressBar.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </h3>\n    </div>\n\n");
#nullable restore
#line 44 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
     foreach (var albumStage in progressBar.albumStages)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg col-md col-sm-6 col-6\">\n            <h4 class=\"album__stage-title\">\n                ");
#nullable restore
#line 48 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
           Write(albumStage.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </h4>\n            \n            \n            <div class=\"bg-style\">\n                <div>\n                    <div class=\"counter\" data-cp-percentage=\"");
#nullable restore
#line 54 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
                                                        Write(albumStage.Progress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-cp-color=\"");
#nullable restore
#line 54 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
                                                                                             Write(progressBar.Color);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"> </div>\n                </div>\n            \n            </div>\n        </div>\n");
#nullable restore
#line 59 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
#nullable restore
#line 62 "C:\Users\tekil\source\repos\ForAfterwind\ForAfterwind\Views\Home\Index.cshtml"
}

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ForAfterwind.ViewModels.HomePageViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
